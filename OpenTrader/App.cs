using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Auth;
using System.Collections.Generic;
using OpenTrader.Pages;

namespace OpenTrader
{
	public class App : Application
	{
		private const string OAUTH_SERVICE_NAME = "cTrader ID";
		// just a singleton pattern so I can have the concept of an app instance
		static volatile App _Instance;
		static object _SyncRoot = new Object();

		private NavigationPage _NavPage;
		private string _Token;
		private static AccountStore accountStore;

		public static App Instance
		{
			get 
			{
				if (_Instance == null) 
				{
					lock (_SyncRoot) 
					{
						if (_Instance == null) {
							_Instance = new App ();
							_Instance.OAuthSettings = 
								new OAuthSettings (
									clientId: "1_6249vt3dcpogwso488wwgsg48co88so84ks4g4o4kwk880g40",  		// your OAuth2 client id 
									scope: "trading",  		// The scopes for the particular API you're accessing. The format for this will vary by API.
									authorizeUrl: "https://connect.spotware.com/oauth/v2/auth",  	// the auth URL for the service
                                    redirectUrl: "https://id.ctrader.com");   // the redirect URL for the service

							        // If you'd like to know more about how to integrate with an OAuth provider, 
									// I personally like the Instagram API docs: http://instagram.com/developer/authentication/
						}
					}
				}

				return _Instance;
			}
		}

		public OAuthSettings OAuthSettings { get; private set; }

		private App ()
		{
			var mainPage = new MainPage();
			_NavPage = new NavigationPage(mainPage);
			MainPage = _NavPage;
		}

		public bool IsAuthenticated {
			get { return !string.IsNullOrWhiteSpace(Token); }
		}

		public string Token {
			get {
				if (_Token == null) {
					IEnumerable<Account> accounts = accountStore.FindAccountsForService (OAUTH_SERVICE_NAME);
					if (accounts.Count() > 0) {
						Account account = accounts.Last ();
						if (account != null) {
							_Token = account.Properties ["access_token"];
						}
					}
				}
				return _Token;
			}
		}

		public void SaveAccount(Account account)
		{
			accountStore.Save (account, OAUTH_SERVICE_NAME);
			_Token = account.Properties ["access_token"];
			// broadcast a message that authentication was successful
			MessagingCenter.Send<App> (this, "Authenticated");
		}

		public Action SuccessfulLoginAction
		{
			get {
				return new Action (() => _NavPage.Navigation.PopModalAsync ());
			}
		}

		public static AccountStore AccountStore {
			get {
				return accountStore;
			} set {
				accountStore = value;
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


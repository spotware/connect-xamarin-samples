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
		/* Live Environment
		public const string OAUTH_SERVICE_NAME = "cTrader ID";
		public const string OAUTH_HOST_URL = "https://connect.spotware.com";
		public const string REDIRECT_HOST_URL = "https://connect.spotware.com";

		public const string ACCOUNTS_API_HOST_URL = "https://api.spotware.com";
		public const string TRADING_API_HOST = "tradeapi.spotware.com";
		public const int TRADING_API_PORT = 5032;

		public const string CLIENT_ID = "1_6249vt3dcpogwso488wwgsg48co88so84ks4g4o4kwk880g40";
		public const string CLIENT_SECRET = "26hily0jjm80w40cck8ckgc8skwgg4owog44g0s8cgocoscgc4";
		*/
		/* Sandbox Environment */
		public const string OAUTH_SERVICE_NAME = "cTrader ID";
		public const string OAUTH_HOST_URL = "https://sandbox-connect.spotware.com";
		public const string REDIRECT_HOST_URL = "https://sandbox-id.ctrader.com";

		public const string ACCOUNTS_API_HOST_URL = "https://sandbox-api.spotware.com";
		public const string TRADING_API_HOST = "sandbox-tradeapi.spotware.com";
		public const int TRADING_API_PORT = 5032;

		public const string CLIENT_ID = "7_5az7pj935owsss8kgokcco84wc8osk0g0gksow0ow4s4ocwwgc";
		public const string CLIENT_SECRET = "49p1ynqfy7c4sw84gwoogwwsk8cocg8ow8gc8o80c0ws448cs4";
		/**/

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
									clientId: CLIENT_ID, // your OAuth2 client id
									clientSecret: CLIENT_SECRET, // your OAuth2 client secret
									scope: "trading",  		// The scopes for the particular API you're accessing. The format for this will vary by API.
									authorizeUrl: OAUTH_HOST_URL + "/oauth/v2/auth",  	// the auth URL for the service
									redirectUrl: REDIRECT_HOST_URL,   // the redirect URL for the service
									accessTokenUrl: OAUTH_HOST_URL + "/oauth/v2/token");  	// the access token URL
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


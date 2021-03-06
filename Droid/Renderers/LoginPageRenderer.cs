﻿using System; 
using Android.App;
using OpenTrader;
using OpenTrader.Droid;
using OpenTrader.Pages;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]
namespace OpenTrader.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

			var auth = new OAuth2Authenticator (
                clientId: App.Instance.OAuthSettings.ClientId, // your OAuth2 client id
				clientSecret: App.Instance.OAuthSettings.ClientSecret, // your OAuth2 client secret
                scope: App.Instance.OAuthSettings.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
                authorizeUrl: new Uri (App.Instance.OAuthSettings.AuthorizeUrl), // the auth URL for the service
                redirectUrl: new Uri (App.Instance.OAuthSettings.RedirectUrl), // the redirect URL for the service
				accessTokenUrl: new Uri (App.Instance.OAuthSettings.AccessTokenUrl)); // the access token URL

            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated) {
                    App.Instance.SuccessfulLoginAction.Invoke();
                    // Use eventArgs.Account to do wonderful things
					App.Instance.SaveAccount(eventArgs.Account);
                } else {
                    // The user cancelled
                }
            };

			auth.Error += (sender, eventArgs) =>
			{
				Console.WriteLine(eventArgs.Message);
			};

            activity.StartActivity (auth.GetUI(activity));
        }
	}
}
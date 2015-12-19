using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace OpenTrader.Droid
{
	[Activity (Label = "OpenTrader.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			global::OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init ();

			LoadApplication (OAuthTwoDemo.XForms.App.Instance);
		}
	}
}


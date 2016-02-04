using Xamarin.Forms;

namespace OpenTrader.Pages
{
	public class BaseContentPage : ContentPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!App.Instance.IsAuthenticated) {
				Navigation.PushModalAsync (new LoginPage ());
			} else {
				MessagingCenter.Send<App> (App.Instance, "Authenticated");
			}
		}
	}
}


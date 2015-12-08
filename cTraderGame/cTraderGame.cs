using System;

using Xamarin.Forms;
using System.Collections.Generic;
using OxyPlot.Xamarin.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OpenApiDeveloperLibrary.Json;
using OpenApiLib.Json;

namespace cTraderGame
{
	public class App : Application
	{
		private const string API_HOST_URL = "https://sandbox-api.spotware.com";
		private const string ACCOUNTS_API_TOKEN = "test002_access_token";
		private AccountsAPI accountsAPI = new AccountsAPI (API_HOST_URL, ACCOUNTS_API_TOKEN);

		private string symbolName = "EURUSD";

		public App ()
		{
			MainPage = new ContentPage { 
				Content = new StackLayout {
					Orientation = StackOrientation.Vertical,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						createTopPanel (),
						createChartPanel (getMinuteTrendbars ()),
						createBottomPanel ()
					}
				},
			};
			// The root page of your application
			//MainPage = new cTraderGame.MainPage();
			//TradingApiTest.Start();
		}

		private TrendbarJson[] getMinuteTrendbars ()
		{
			String accountId = "62002";
			DateTime to = DateTime.Now;
			DateTime from = to.AddHours (-5);
			return accountsAPI.getMinuteTredbars (accountId, symbolName, from, to);
		}


		private View createTopPanel ()
		{
			StackLayout panel = new StackLayout {
				Spacing = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					new Label {
						Text = "Duel EUR/USD",
						HorizontalOptions = LayoutOptions.Start
					}
				}
			};
			return panel;
		}

		private View createChartPanel (TrendbarJson[] data)
		{
			PlotView panel = new PlotView {
				Model = CandleStickSeries (data),
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			return panel;
		}

		private View createBottomPanel ()
		{
			Dictionary<string, int> nameToVolume = new Dictionary<string, int> {
				{ "1000", 1000 },
				{ "10 000", 10000 },
				{ "100 000", 100000 },
				{ "1 000 000", 1000000 }
			};
			Picker picker = new Picker {
				Title = "Volume",
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			foreach (string volumeLabel in nameToVolume.Keys) {
				picker.Items.Add (volumeLabel);
			}
			StackLayout panel = new StackLayout {
				Spacing = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					picker,
					new Button {
						Text = "Buy"
					},
					new Button {
						Text = "Sell"
					}
				}
			};
			return panel;
		}

		public PlotModel CandleStickSeries (TrendbarJson[] data)
		{
			var model = new PlotModel { Title = "CandleStickSeries", LegendSymbolLength = 24 };
			var s1 = new OxyPlot.Series.CandleStickSeries {
				Title = symbolName,
				Color = OxyColors.Black,
			};
			foreach (TrendbarJson item in data) {
				s1.Items.Add (new HighLowItem (item.Timestamp, item.High, item.Low, item.Open, item.Close));
			}

			model.Series.Add (s1);
			model.Axes.Add (new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.3, MinimumPadding = 0.3 });
			model.Axes.Add (new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.03, MinimumPadding = 0.03 });

			return model;
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


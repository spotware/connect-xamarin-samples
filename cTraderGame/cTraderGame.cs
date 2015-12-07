using System;

using Xamarin.Forms;
using System.Collections.Generic;
using OxyPlot.Xamarin.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace cTraderGame
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new ContentPage { 
				Content = new StackLayout {
					Orientation = StackOrientation.Vertical,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						createTopPanel(),
						createChartPanel(),
						createBottomPanel()
					}
				},
			};
			// The root page of your application
			//MainPage = new cTraderGame.MainPage();
			//TradingApiTest.Start();
		}

		private View createTopPanel() {
			StackLayout panel = new StackLayout
			{
				Spacing = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{
					new Label
					{
						Text = "Duel EUR/USD",
						HorizontalOptions = LayoutOptions.Start
					}
				}
			};
			return panel;
		}

		private View createChartPanel() {
			PlotView panel = new PlotView {
				Model = CandleStickSeries(),
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			return panel;
		}

		private View createBottomPanel() {
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

			foreach (string volumeLabel in nameToVolume.Keys)
			{
				picker.Items.Add(volumeLabel);
			}
			StackLayout panel = new StackLayout
			{
				Spacing = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{
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

		public static PlotModel CandleStickSeries()
		{
			var model = new PlotModel { Title = "CandleStickSeries", LegendSymbolLength = 24 };
			var s1 = new OxyPlot.Series.CandleStickSeries
			{
				Title = "CandleStickSeries 1",
				Color = OxyColors.Black,
			};
			var r = new Random(314);
			var price = 100.0;
			for (int x = 0; x < 16; x++)
			{
				price = price + r.NextDouble() + 0.1;
				var high = price + 10 + (r.NextDouble() * 10);
				var low = price - (10 + (r.NextDouble() * 10));
				var open = low + (r.NextDouble() * (high - low));
				var close = low + (r.NextDouble() * (high - low));
				s1.Items.Add(new HighLowItem(x, high, low, open, close));
			}

			model.Series.Add(s1);
			model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.3, MinimumPadding = 0.3 });
			model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.03, MinimumPadding = 0.03 });

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


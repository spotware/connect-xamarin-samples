using Xamarin.Forms;
using System.Collections.Generic;
using OpenTrader.Proto;
using OpenApiDeveloperLibrary.Json;
using OpenApiLib.Json;
using System;
using OxyPlot.Xamarin.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Annotations;
using OpenApiLib.Proto;

namespace OpenTrader.Pages
{
	public class MainPage : BaseContentPage
	{
		private const string ACCOUNTS_API_HOST_URL = "https://api.spotware.com";
		private const string TRADING_API_HOST = "tradeapi.spotware.com";
		private const int TRADING_API_PORT = 5032;

		private AccountsAPI accountsAPI;
		private TradingAPI tradingAPI;
		private string symbolName = "EURUSD";

		private Dictionary<string, int> nameToVolume = new Dictionary<string, int> {
			{ "1000", 100000 },
			{ "10 000", 1000000 },
			{ "100 000", 10000000 },
			{ "1 000 000", 100000000 }
		};

		private TradingAccountJson[] tradingAccounts;

		private PlotView plotView;
		private TradingButton buyButton;
		private TradingButton sellButton;

		public MainPage ()
		{
			this.plotView = createChartPanel();
			this.buyButton = new TradingButton ("Buy");
			this.sellButton = new TradingButton("Sell");

			this.Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					createTopPanel (),
					this.plotView,
					createBottomPanel ()
				}
			};
			// Using messaging center to ensure that content only gets loaded once authentication is successful.
			// Once Xamarin.Forms adds more support for view life cycle events, this kind of thing won't be as necessary.
			// The OnAppearing() and OnDisappearing() overrides just don't quite cut the mustard yet, nor do the Appearing and Disappearing delegates.
			MessagingCenter.Subscribe<App> (this, "Authenticated", (sender) => {
				accountsAPI = new AccountsAPI (ACCOUNTS_API_HOST_URL, App.Instance.Token);
				tradingAPI = new TradingAPI (TRADING_API_HOST, TRADING_API_PORT, App.Instance.Token);
				tradingAccounts = accountsAPI.getTradingAccounts();

				this.plotView.Model = CandleStickSeries (getMinuteTrendbars (tradingAccounts[0]));

				tradingAPI.Start ();
				tradingAPI.ExecutionEvent += (executionEvent) => {
					Device.BeginInvokeOnMainThread (() => {
						String filledTitle = "Order Filled at {0}";
						String filledMessage = "Your request to {0} {1} of {2} was filled at VWAP {3}";
						if (executionEvent.executionType == ProtoOAExecutionType.OA_ORDER_FILLED) {
							ProtoOAOrder order = executionEvent.order;
							string title = String.Format (filledTitle, order.executionPrice);
							string message = String.Format (filledMessage, order.tradeSide, order.requestedVolume / 100, order.symbolName, order.executionPrice);
							DisplayAlert (title, message, "Close");
						}
					});
				};
				tradingAPI.SpotEvent += (spotEvent) => {
					Device.BeginInvokeOnMainThread (() => {
						if (spotEvent.askPriceSpecified) {
							buyButton.setPrice (spotEvent.askPrice);
						}
						if (spotEvent.bidPriceSpecified) {
							sellButton.setPrice (spotEvent.bidPrice);
						}
					});
				};
			});
		}

		private TrendbarJson[] getMinuteTrendbars (TradingAccountJson account)
		{
			DateTime to = DateTime.Now;
			DateTime from = to.AddHours (-3);
			return accountsAPI.getMinuteTredbars (account.getAccountId(), symbolName, from, to);
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

		private PlotView createChartPanel ()
		{
			PlotView panel = new PlotView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			return panel;
		}

		private View createBottomPanel ()
		{
			Picker picker = new Picker {
				Title = "Volume",
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			foreach (string volumeLabel in nameToVolume.Keys) {
				picker.Items.Add (volumeLabel);
			}
			picker.SelectedIndex = 0;
			buyButton.HorizontalOptions = LayoutOptions.End;
			buyButton.Clicked += (object sender, EventArgs e) => tradingAPI.SendMarketOrderRequest(symbolName, ProtoTradeSide.BUY, nameToVolume[picker.Items[picker.SelectedIndex]]);

			sellButton.HorizontalOptions = LayoutOptions.End;
			sellButton.Clicked += (object sender, EventArgs e) => tradingAPI.SendMarketOrderRequest(symbolName, ProtoTradeSide.SELL, nameToVolume[picker.Items[picker.SelectedIndex]]);

			StackLayout panel = new StackLayout {
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					picker,
					buyButton,
					sellButton,
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

			var arrowAnnotation = new LineAnnotation {
				Type = LineAnnotationType.Horizontal,
				Y = data[data.Length - 1].Close,
				Text = data[data.Length - 1].Close.ToString()
			};
			model.Annotations.Add(arrowAnnotation);
			return model;
		}
		public class TradingButton : Button {
			private double previousPrice;
			private string title;

			public TradingButton(string title) {
				this.title = title;
				Text = title;
			}

			public void setPrice(double price) {
				if (price > previousPrice) {
					BackgroundColor = Color.FromRgb (38, 127, 0);
				} else if (price < previousPrice){
					BackgroundColor = Color.FromHex ("FF6A00");
				}
				Text = title + " [" + price + "]";
				previousPrice = price;
			}
		}
	}
}


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
		private AccountsAPI accountsAPI;
		private TradingAPI tradingAPI;

		private Dictionary<string, int> nameToVolume = new Dictionary<string, int> {
			{ "1k", 100000 },
			{ "10k", 1000000 },
			{ "100k", 10000000 },
			{ "1M", 100000000 }
		};

		private TradingAccountJson[] tradingAccounts;
		private TradingAccountJson currentTradingAccount;
		private SymbolJson[] symbols;
		private SymbolJson currentSymbol;

		private Picker accountPicker;
		private PlotView plotView;
		private Picker symbolPicker;
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
				accountsAPI = new AccountsAPI (App.ACCOUNTS_API_HOST_URL, App.Instance.Token);
				tradingAPI = new TradingAPI (App.TRADING_API_HOST, App.TRADING_API_PORT, App.Instance.Token, App.CLIENT_ID, App.CLIENT_SECRET);

				fillAccounts();
				fillSymbols();
				refreshPlotView ();

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
					if (spotEvent.symbolName.Equals(currentSymbol.SymbolName)) {
						if (spotEvent.askPriceSpecified) {
							LineAnnotation annotation = (LineAnnotation)plotView.Model.Annotations[0];
							annotation.Y = spotEvent.askPrice;
							annotation.Text = spotEvent.askPrice.ToString();
						}
						Device.BeginInvokeOnMainThread (() => {
							if (spotEvent.askPriceSpecified) {
								buyButton.setPrice (spotEvent.askPrice);
								plotView.Model.InvalidatePlot(true);
							}
							if (spotEvent.bidPriceSpecified) {
								sellButton.setPrice (spotEvent.bidPrice);
							}
						});
					}
				};
				tradingAPI.SendSubscribeForTradingEventsRequest (currentTradingAccount.AccountId);
				tradingAPI.SendSubscribeForSpotsRequest (currentTradingAccount.AccountId, currentSymbol.SymbolName);
			});
		}

		private void fillAccounts ()
		{
			tradingAccounts = accountsAPI.getTradingAccounts();
			foreach (TradingAccountJson tradingAccount in tradingAccounts) {
				accountPicker.Items.Add (tradingAccount.Live ? "Live" : "Demo " + tradingAccount.AccountNumber + " - " + tradingAccount.BrokerTitle);
			}
			accountPicker.SelectedIndex = 0;
			currentTradingAccount = tradingAccounts[accountPicker.SelectedIndex];
		}

		private void fillSymbols ()
		{
			string oldSymbol = null;
			if (symbolPicker.Items.Count > 0) {
				oldSymbol = symbolPicker.Items [symbolPicker.SelectedIndex];
				symbolPicker.Items.Clear ();
			}
			symbols = accountsAPI.getSymbols (currentTradingAccount.AccountId);
			int selectedIndex = 0;
			foreach (SymbolJson symbol in symbols) {
				symbolPicker.Items.Add (symbol.SymbolName);
				if (symbol.SymbolName.Equals(oldSymbol)) {
					selectedIndex = symbolPicker.Items.Count - 1;
				}
			}
			symbolPicker.SelectedIndex = selectedIndex;
			currentSymbol = symbols[symbolPicker.SelectedIndex];
		}

		private void refreshPlotView () {
			this.plotView.Model = LineSeries (getMinuteTrendbars ());
		}

		private TrendbarJson[] getMinuteTrendbars ()
		{
			DateTime to = DateTime.Now;
			DateTime from = to.AddHours (-3);
			return accountsAPI.getMinuteTredbars (currentTradingAccount.AccountId, currentSymbol.SymbolName, from, to);
		}

		private View createTopPanel ()
		{
			accountPicker = new Picker {
				Title = "Account",
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			accountPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
				if (accountPicker.SelectedIndex > -1) {
					currentTradingAccount = tradingAccounts[accountPicker.SelectedIndex];
					tradingAPI.SendSubscribeForTradingEventsRequest (currentTradingAccount.AccountId);
					fillSymbols();
					tradingAPI.SendSubscribeForSpotsRequest (currentTradingAccount.AccountId, currentSymbol.SymbolName);
					refreshPlotView();
				}
			};

			StackLayout panel = new StackLayout {
				Spacing = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					accountPicker
				}
			};
			return panel;
		}

		private PlotView createChartPanel ()
		{
			PlotView panel = new PlotView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			return panel;
		}

		private View createBottomPanel ()
		{
			symbolPicker = new Picker {
				Title = "Symbol",
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			symbolPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
				if (symbolPicker.SelectedIndex > -1) {
					currentSymbol = symbols[symbolPicker.SelectedIndex];
					tradingAPI.SendSubscribeForSpotsRequest (currentTradingAccount.AccountId, currentSymbol.SymbolName);
					refreshPlotView();
				}
			};
			Picker volumePicker = new Picker {
				Title = "Volume",
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			foreach (string volumeLabel in nameToVolume.Keys) {
				volumePicker.Items.Add (volumeLabel);
			}
			volumePicker.SelectedIndex = 0;
			buyButton.HorizontalOptions = LayoutOptions.End;
			buyButton.Clicked += (object sender, EventArgs e) => tradingAPI.SendMarketOrderRequest(currentTradingAccount.AccountId, currentSymbol.SymbolName, ProtoTradeSide.BUY, nameToVolume[volumePicker.Items[volumePicker.SelectedIndex]]);

			sellButton.HorizontalOptions = LayoutOptions.End;
			sellButton.Clicked += (object sender, EventArgs e) => tradingAPI.SendMarketOrderRequest(currentTradingAccount.AccountId, currentSymbol.SymbolName, ProtoTradeSide.SELL, nameToVolume[volumePicker.Items[volumePicker.SelectedIndex]]);

			StackLayout panel = new StackLayout {
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					this.symbolPicker,
					volumePicker,
					buyButton,
					sellButton,
				}
			};
			return panel;
		}

		public PlotModel CandleStickSeries (TrendbarJson[] data)
		{
			var model = new PlotModel { 
				Title = "CandleStickSeries",
				LegendSymbolLength = 24,
			};
			var s1 = new OxyPlot.Series.CandleStickSeries {
				Title = currentSymbol.SymbolName,
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

		public PlotModel LineSeries (TrendbarJson[] data)
		{
			var model = new PlotModel { Title = "LineSeries", LegendSymbolLength = 24 };
			var s1 = new OxyPlot.Series.LineSeries {
				Title = currentSymbol.SymbolName,
				Color = OxyColors.Orange,
			};
			foreach (TrendbarJson item in data) {
				s1.Points.Add (new DataPoint (item.Timestamp, item.Close));
			}

			model.Series.Add (s1);
			model.Axes.Add (new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.3, MinimumPadding = 0.3 });
			model.Axes.Add (new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.03, MinimumPadding = 0.03 });

			var arrowAnnotation = new LineAnnotation {
				Type = LineAnnotationType.Horizontal,
				Color = OxyColors.Red,
				Y = data[data.Length - 1].Close,
				Text = data[data.Length - 1].Close.ToString(),
				TextColor = OxyColors.White
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


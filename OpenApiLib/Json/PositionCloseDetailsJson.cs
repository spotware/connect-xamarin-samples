using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class PositionCloseDetailsJson : AbstractJson
	{
		public double EntryPrice { get; set; }
		public long Profit { get; set; }
		public long Swap { get; set; }
		public long Commission { get; set; }
		public long Balance { get; set; }
		public long BalanceVersion { get; set; }
		public string Comment { get; set; }
		public double StopLossPrice { get; set; }
		public double TakeProfitPrice { get; set; }
		public double QuoteToDepositConversionRate { get; set; }
		public long ClosedVolume { get; set; }
		public double ProfitInPips { get; set; }
		public double Roi { get; set; }
		public long Equity { get; set; }
		public long PositionOpenTimestamp { get; set; }
	}
}

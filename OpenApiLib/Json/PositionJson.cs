using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class PositionJson : AbstractJson
	{
		public long PositionId { get; set; }
		public long EntryTimestamp { get; set; }
		public long UtcLastUpdateTimestamp { get; set; }
		public string SymbolName { get; set; }
		public string TradeSide { get; set; }
		public double EntryPrice { get; set; }
		public long Volume { get; set; }
		public double StopLoss { get; set; }
		public double TakeProfit { get; set; }
		public long Profit { get; set; }
		public double ProfitInPips { get; set; }
		public long Commission { get; set; }
		public double MarginRate { get; set; }
		public long Swap { get; set; }
		public double CurrentPrice { get; set; }
		public string Comment { get; set; }
		public string Channel { get; set; }
		public string Label { get; set; }
	}
}

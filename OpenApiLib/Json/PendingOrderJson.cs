using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class PendingOrderJson : AbstractJson
	{
		public long OrderId { get; set; }
		public string SymbolName { get; set; }
		public string OrderType { get; set; }
		public string TradeSide { get; set; }
		public double Price { get; set; }
		public long Volume { get; set; }
		public double StopLoss { get; set; }
		public double TakeProfit { get; set; }
		public long CreateTimestamp { get; set; }
		public long ExpirationTimestamp { get; set; }
		public double CurrentPrice { get; set; }
		public double DistanceInPips { get; set; }
		public string Comment { get; set; }
		public string Channel { get; set; }
		public string Label { get; set; }
	}
}

using OpenApiLib.Json.Enums;

namespace OpenApiLib.Json
{
	public class DealJson : AbstractJson
	{
		public long DealId { get; set; }
		public long PositionId { get; set; }
		public long OrderId { get; set; }
		public TradeSideType TradeSide { get; set; }
		public long Volume { get; set; }
		public long FilledVolume { get; set; }
		public string SymbolName { get; set; }
		public long Commission { get; set; }
		public double ExecutionPrice { get; set; }
		public double BaseToUsdConversionRate { get; set; }
		public double MarginRate { get; set; }
		public string Channel { get; set; }
		public string Label { get; set; }
		public string Comment { get; set; }
		public long CreateTimestamp { get; set; }
		public long ExecutionTimestamp { get; set; }
		public PositionCloseDetailsJson PositionCloseDetails;
	}
}

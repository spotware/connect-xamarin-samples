using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class SymbolJson : AbstractJson
	{
		public string SymbolName { get; set; }
		public int Digits { get; set; }
		public int PipPosition { get; set; }
		public string MeasurementUnits { get; set; }
		public string BaseAsset { get; set; }
		public string QuoteAsset { get; set; }
		public bool TradeEnabled { get; set; }
		public double TickSize { get; set; }
		public string Description { get; set; }
		public int MaxLeverage{ get; set; }
		public long MinOrderVolume{ get; set; }
		public long MinOrderStep{ get; set; }
		public long MaxOrderVolume{ get; set; }
		public double SwapLong{ get; set; }
		public double SwapShort{ get; set; }
		public string ThreeDaysSwaps{ get; set; }
		public string AssetClass{ get; set; }
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public double LastAsk{ get; set; }
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public double LastBid{ get; set; }
	}
}

using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class TradingAccountJson : AbstractJson
	{
		public long AccountId { get; set; }
		public long AccountNumber{ get; set; }
		public bool Live { get; set; }
		public string BrokerName { get; set; }
		public string BrokerTitle { get; set; }
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public long BrokerCode { get; set; }
		public string DepositCurrency { get; set; }
		public long TraderRegistrationTimestamp { get; set; }
		public string TraderAccountType { get; set; }
		public int Leverage { get; set; }
		public long Balance { get; set; }
		public bool Deleted { get; set; }
	}
}

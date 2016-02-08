namespace OpenApiLib.Json
{
	public class CashflowJson : AbstractJson
	{
		public long CashflowId { get; set; }
		public string Type  { get; set; }
		public long Delta  { get; set; }
		public long Balance  { get; set; }
		public long BalanceVersion { get; set; }
		public long ChangeTimestamp { get; set; }
		public long Equity { get; set; }
	}
}

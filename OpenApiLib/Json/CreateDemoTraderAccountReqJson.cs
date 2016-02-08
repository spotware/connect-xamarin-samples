namespace OpenApiLib.Json
{
	public class CreateDemoTraderAccountReqJson : AbstractJson
	{
		public long CountryId  { get; set; }
		public string PhoneNumber  { get; set; }
		public int Leverage  { get; set; }
		public long Balance  { get; set; }
		public string DepositCurrency  { get; set; }
		public string Password  { get; set; }
		public string AccountType  { get; set; }
	}
}

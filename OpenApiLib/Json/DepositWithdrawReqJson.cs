namespace OpenApiLib.Json
{
	public class DepositWithdrawReqJson
	{
		private long amount;

		public virtual long getAmount()
		{
			return amount;
		}

		public virtual void setAmount(long amount)
		{
			this.amount = amount;
		}
	}
}

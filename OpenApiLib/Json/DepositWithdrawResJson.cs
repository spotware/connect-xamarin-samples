namespace OpenApiLib.Json
{
	public class DepositWithdrawResJson
	{
		private long cashflowId;

		public virtual long getCashflowId()
		{
			return cashflowId;
		}

		public virtual void setCashflowId(long cashflowId)
		{
			this.cashflowId = cashflowId;
		}
	}
}

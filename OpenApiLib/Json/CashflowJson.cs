using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class CashflowJson
	{
		private long cashflowId;

		private string type;

		private long delta;

		private long balance;

		private long balanceVersion;

		private long changeTimestamp;

		private long equity;

		public virtual long getCashflowId()
		{
			return cashflowId;
		}

		public virtual string getType()
		{
			return type;
		}

		public virtual long getDelta()
		{
			return delta;
		}

		public virtual long getBalance()
		{
			return balance;
		}

		public virtual long getBalanceVersion()
		{
			return balanceVersion;
		}

		public virtual long getChangeTimestamp()
		{
			return changeTimestamp;
		}

		public virtual void setCashflowId(long cashflowId)
		{
			this.cashflowId = cashflowId;
		}

		public virtual void setType(string type)
		{
			this.type = type;
		}

		public virtual void setDelta(long delta)
		{
			this.delta = delta;
		}

		public virtual void setBalance(long balance)
		{
			this.balance = balance;
		}

		public virtual void setBalanceVersion(long balanceVersion)
		{
			this.balanceVersion = balanceVersion;
		}

		public virtual void setChangeTimestamp(long changeTimestamp)
		{
			this.changeTimestamp = changeTimestamp;
		}

		public virtual long getEquity()
		{
			return equity;
		}

		public virtual void setEquity(long equity)
		{
			this.equity = equity;
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

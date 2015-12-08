namespace OpenApiLib.Json
{
	public class TradingAccountJson
	{
		private long accountId;

		private long accountNumber;

		private bool live;

		private string brokerName;

		private string brokerTitle;

		private long brokerCode;

		private string depositCurrency;

		private long traderRegistrationTimestamp;

		private string traderAccountType;

		private int leverage;

		private long balance;

		private bool deleted;

		public virtual long getAccountId()
		{
			return accountId;
		}

		public virtual void setAccountId(long accountId)
		{
			this.accountId = accountId;
		}

		public virtual long getAccountNumber()
		{
			return accountNumber;
		}

		public virtual void setAccountNumber(long accountNumber)
		{
			this.accountNumber = accountNumber;
		}

		public virtual bool isLive()
		{
			return live;
		}

		public virtual void setLive(bool live)
		{
			this.live = live;
		}

		public virtual string getBrokerTitle()
		{
			return brokerTitle;
		}

		public virtual void setBrokerTitle(string brokerTitle)
		{
			this.brokerTitle = brokerTitle;
		}

		public virtual long getBrokerCode()
		{
			return brokerCode;
		}

		public virtual void setBrokerCode(long brokerCode)
		{
			this.brokerCode = brokerCode;
		}

		public virtual string getDepositCurrency()
		{
			return depositCurrency;
		}

		public virtual void setDepositCurrency(string depositCurrency)
		{
			this.depositCurrency = depositCurrency;
		}

		public virtual long getTraderRegistrationTimestamp()
		{
			return traderRegistrationTimestamp;
		}

		public virtual void setTraderRegistrationTimestamp(long traderRegistrationTimestamp
			)
		{
			this.traderRegistrationTimestamp = traderRegistrationTimestamp;
		}

		public virtual string getTraderAccountType()
		{
			return traderAccountType;
		}

		public virtual void setTraderAccountType(string traderAccountType)
		{
			this.traderAccountType = traderAccountType;
		}

		public virtual int getLeverage()
		{
			return leverage;
		}

		public virtual void setLeverage(int leverage)
		{
			this.leverage = leverage;
		}

		public virtual long getBalance()
		{
			return balance;
		}

		public virtual void setBalance(long balance)
		{
			this.balance = balance;
		}

		public virtual bool getDeleted()
		{
			return deleted;
		}

		public virtual void setDeleted(bool deleted)
		{
			this.deleted = deleted;
		}

		public virtual string getBrokerName()
		{
			return brokerName;
		}

		public virtual void setBrokerName(string brokerName)
		{
			this.brokerName = brokerName;
		}
	}
}

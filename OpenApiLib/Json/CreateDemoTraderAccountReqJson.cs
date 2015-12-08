namespace OpenApiLib.Json
{
	public class CreateDemoTraderAccountReqJson
	{
		private long countryId;

		private string phoneNumber;

		private int leverage;

		private long balance;

		private string depositCurrency;

		private string password;

		private string accountType;

		public virtual long getCountryId()
		{
			return countryId;
		}

		public virtual void setCountryId(long countryId)
		{
			this.countryId = countryId;
		}

		public virtual string getPhoneNumber()
		{
			return phoneNumber;
		}

		public virtual void setPhoneNumber(string phoneNumber)
		{
			this.phoneNumber = phoneNumber;
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

		public virtual string getDepositCurrency()
		{
			return depositCurrency;
		}

		public virtual void setDepositCurrency(string depositCurrency)
		{
			this.depositCurrency = depositCurrency;
		}

		public virtual string getPassword()
		{
			return password;
		}

		public virtual void setPassword(string password)
		{
			this.password = password;
		}

		public virtual string getAccountType()
		{
			return accountType;
		}

		public virtual void setAccountType(string accountType)
		{
			this.accountType = accountType;
		}

		public override string ToString()
		{
			return org.apache.commons.lang3.builder.ToStringBuilder.reflectionToString(this, 
				org.apache.commons.lang3.builder.ToStringStyle.SHORT_PREFIX_STYLE);
		}
	}
}

using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class PositionCloseDetailsJson
	{
		private double entryPrice;

		private long profit;

		private long swap;

		private long commission;

		private long balance;

		private long balanceVersion;

		private string comment;

		private double stopLossPrice;

		private double takeProfitPrice;

		private double quoteToDepositConversionRate;

		private long closedVolume;

		private double profitInPips;

		private double roi;

		private long equity;

		private long positionOpenTimestamp;

		public virtual double getEntryPrice()
		{
			return entryPrice;
		}

		public virtual void setEntryPrice(double entryPrice)
		{
			this.entryPrice = entryPrice;
		}

		public virtual long getProfit()
		{
			return profit;
		}

		public virtual void setProfit(long profit)
		{
			this.profit = profit;
		}

		public virtual long getSwap()
		{
			return swap;
		}

		public virtual void setSwap(long swap)
		{
			this.swap = swap;
		}

		public virtual long getCommission()
		{
			return commission;
		}

		public virtual void setCommission(long commission)
		{
			this.commission = commission;
		}

		public virtual long getBalance()
		{
			return balance;
		}

		public virtual void setBalance(long balance)
		{
			this.balance = balance;
		}

		public virtual long getBalanceVersion()
		{
			return balanceVersion;
		}

		public virtual void setBalanceVersion(long balanceVersion)
		{
			this.balanceVersion = balanceVersion;
		}

		public virtual long getClosedVolume()
		{
			return closedVolume;
		}

		public virtual void setClosedVolume(long closedVolume)
		{
			this.closedVolume = closedVolume;
		}

		public virtual string getComment()
		{
			return comment;
		}

		public virtual void setComment(string comment)
		{
			this.comment = comment;
		}

		public virtual double getStopLossPrice()
		{
			return stopLossPrice;
		}

		public virtual void setStopLossPrice(double stopLossPrice)
		{
			this.stopLossPrice = stopLossPrice;
		}

		public virtual double getTakeProfitPrice()
		{
			return takeProfitPrice;
		}

		public virtual void setTakeProfitPrice(double takeProfitPrice)
		{
			this.takeProfitPrice = takeProfitPrice;
		}

		public virtual double getQuoteToDepositConversionRate()
		{
			return quoteToDepositConversionRate;
		}

		public virtual void setQuoteToDepositConversionRate(double quoteToDepositConversionRate
			)
		{
			this.quoteToDepositConversionRate = quoteToDepositConversionRate;
		}

		public virtual double getProfitInPips()
		{
			return profitInPips;
		}

		public virtual void setProfitInPips(double profitInPips)
		{
			this.profitInPips = profitInPips;
		}

		public virtual double getRoi()
		{
			return roi;
		}

		public virtual void setRoi(double roi)
		{
			this.roi = roi;
		}

		public virtual long getEquity()
		{
			return equity;
		}

		public virtual void setEquity(long equity)
		{
			this.equity = equity;
		}

		public virtual long getPositionOpenTimestamp()
		{
			return positionOpenTimestamp;
		}

		public virtual void setPositionOpenTimestamp(long positionOpenTimestamp)
		{
			this.positionOpenTimestamp = positionOpenTimestamp;
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

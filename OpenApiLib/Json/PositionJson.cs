using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class PositionJson
	{
		private long positionId;

		private long entryTimestamp;

		private long utcLastUpdateTimestamp;

		private string symbolName;

		private string tradeSide;

		private double entryPrice;

		private long volume;

		private double stopLoss;

		private double takeProfit;

		private long profit;

		private double profitInPips;

		private long commission;

		private double marginRate;

		private long swap;

		private double currentPrice;

		private string comment;

		private string channel;

		private string label;

		public virtual long getPositionId()
		{
			return positionId;
		}

		public virtual long getEntryTimestamp()
		{
			return entryTimestamp;
		}

		public virtual long getUtcLastUpdateTimestamp()
		{
			return utcLastUpdateTimestamp;
		}

		public virtual string getSymbolName()
		{
			return symbolName;
		}

		public virtual string getTradeSide()
		{
			return tradeSide;
		}

		public virtual long getVolume()
		{
			return volume;
		}

		public virtual double getStopLoss()
		{
			return stopLoss;
		}

		public virtual double getTakeProfit()
		{
			return takeProfit;
		}

		public virtual double getEntryPrice()
		{
			return entryPrice;
		}

		public virtual long getProfit()
		{
			return profit;
		}

		public virtual double getProfitInPips()
		{
			return profitInPips;
		}

		public virtual long getCommission()
		{
			return commission;
		}

		public virtual double getMarginRate()
		{
			return marginRate;
		}

		public virtual long getSwap()
		{
			return swap;
		}

		public virtual string getComment()
		{
			return comment;
		}

		public virtual string getChannel()
		{
			return channel;
		}

		public virtual string getLabel()
		{
			return label;
		}

		public virtual void setPositionId(long positionId)
		{
			this.positionId = positionId;
		}

		public virtual void setEntryTimestamp(long entryTimestamp)
		{
			this.entryTimestamp = entryTimestamp;
		}

		public virtual void setUtcLastUpdateTimestamp(long utcLastUpdateTimestamp)
		{
			this.utcLastUpdateTimestamp = utcLastUpdateTimestamp;
		}

		public virtual void setSymbolName(string symbolName)
		{
			this.symbolName = symbolName;
		}

		public virtual void setTradeSide(string tradeSide)
		{
			this.tradeSide = tradeSide;
		}

		public virtual void setVolume(long volume)
		{
			this.volume = volume;
		}

		public virtual void setStopLoss(double stopLoss)
		{
			this.stopLoss = stopLoss;
		}

		public virtual void setTakeProfit(double takeProfit)
		{
			this.takeProfit = takeProfit;
		}

		public virtual void setEntryPrice(double entryPrice)
		{
			this.entryPrice = entryPrice;
		}

		public virtual void setProfit(long profit)
		{
			this.profit = profit;
		}

		public virtual void setProfitInPips(double profitInPips)
		{
			this.profitInPips = profitInPips;
		}

		public virtual void setCommission(long commission)
		{
			this.commission = commission;
		}

		public virtual void setMarginRate(double marginRate)
		{
			this.marginRate = marginRate;
		}

		public virtual void setSwap(long swap)
		{
			this.swap = swap;
		}

		public virtual double getCurrentPrice()
		{
			return currentPrice;
		}

		public virtual void setCurrentPrice(double currentPrice)
		{
			this.currentPrice = currentPrice;
		}

		public virtual void setComment(string comment)
		{
			this.comment = comment;
		}

		public virtual void setChannel(string channel)
		{
			this.channel = channel;
		}

		public virtual void setLabel(string label)
		{
			this.label = label;
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

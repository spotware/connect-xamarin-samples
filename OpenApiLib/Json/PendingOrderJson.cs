namespace OpenApiLib.Json
{
	public class PendingOrderJson
	{
		private long orderId;

		private string symbolName;

		private string orderType;

		private string tradeSide;

		private double price;

		private long volume;

		private double stopLoss;

		private double takeProfit;

		private long createTimestamp;

		private long expirationTimestamp;

		private double currentPrice;

		private double distanceInPips;

		private string comment;

		private string channel;

		private string label;

		public virtual long getOrderId()
		{
			return orderId;
		}

		public virtual long getCreateTimestamp()
		{
			return createTimestamp;
		}

		public virtual string getSymbolName()
		{
			return symbolName;
		}

		public virtual string getOrderType()
		{
			return orderType;
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

		public virtual double getPrice()
		{
			return price;
		}

		public virtual long getExpirationTimestamp()
		{
			return expirationTimestamp;
		}

		public virtual double getCurrentPrice()
		{
			return currentPrice;
		}

		public virtual double getDistanceInPips()
		{
			return distanceInPips;
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

		public virtual void setOrderId(long orderId)
		{
			this.orderId = orderId;
		}

		public virtual void setCreateTimestamp(long createTimestamp)
		{
			this.createTimestamp = createTimestamp;
		}

		public virtual void setSymbolName(string symbolName)
		{
			this.symbolName = symbolName;
		}

		public virtual void setOrderType(string orderType)
		{
			this.orderType = orderType;
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

		public virtual void setPrice(double price)
		{
			this.price = price;
		}

		public virtual void setExpirationTimestamp(long expirationTimestamp)
		{
			this.expirationTimestamp = expirationTimestamp;
		}

		public virtual void setCurrentPrice(double currentPrice)
		{
			this.currentPrice = currentPrice;
		}

		public virtual void setDistanceInPips(double distanceInPips)
		{
			this.distanceInPips = distanceInPips;
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
			return org.apache.commons.lang3.builder.ToStringBuilder.reflectionToString(this, 
				org.apache.commons.lang3.builder.ToStringStyle.SHORT_PREFIX_STYLE);
		}
	}
}

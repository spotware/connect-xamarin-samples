using OpenApiLib.Json.Enums;
using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class DealJson
	{
		private long dealId;

		private long positionId;

		private long orderId;

		private TradeSideType tradeSide;

		private long volume;

		private long filledVolume;

		private string symbolName;

		private long commission;

		private double executionPrice;

		private double baseToUsdConversionRate;

		private double marginRate;

		private string channel;

		private string label;

		private string comment;

		private long createTimestamp;

		private long executionTimestamp;

		private PositionCloseDetailsJson positionCloseDetails;

		public virtual long getDealId ()
		{
			return dealId;
		}

		public virtual void setDealId (long dealId)
		{
			this.dealId = dealId;
		}

		public virtual long getPositionId ()
		{
			return positionId;
		}

		public virtual void setPositionId (long positionId)
		{
			this.positionId = positionId;
		}

		public virtual long getOrderId ()
		{
			return orderId;
		}

		public virtual void setOrderId (long orderId)
		{
			this.orderId = orderId;
		}

		public virtual TradeSideType getTradeSide ()
		{
			return tradeSide;
		}

		public virtual void setTradeSide (TradeSideType tradeSide)
		{
			this.tradeSide = tradeSide;
		}

		public virtual long getVolume ()
		{
			return volume;
		}

		public virtual void setVolume (long volume)
		{
			this.volume = volume;
		}

		public virtual long getFilledVolume ()
		{
			return filledVolume;
		}

		public virtual void setFilledVolume (long filledVolume)
		{
			this.filledVolume = filledVolume;
		}

		public virtual string getSymbolName ()
		{
			return symbolName;
		}

		public virtual void setSymbolName (string symbolName)
		{
			this.symbolName = symbolName;
		}

		public virtual long getCommission ()
		{
			return commission;
		}

		public virtual void setCommission (long commission)
		{
			this.commission = commission;
		}

		public virtual double getExecutionPrice ()
		{
			return executionPrice;
		}

		public virtual void setExecutionPrice (double executionPrice)
		{
			this.executionPrice = executionPrice;
		}

		public virtual double getBaseToUsdConversionRate ()
		{
			return baseToUsdConversionRate;
		}

		public virtual void setBaseToUsdConversionRate (double baseToUsdConversionRate)
		{
			this.baseToUsdConversionRate = baseToUsdConversionRate;
		}

		public virtual double getMarginRate ()
		{
			return marginRate;
		}

		public virtual void setMarginRate (double marginRate)
		{
			this.marginRate = marginRate;
		}

		public virtual string getChannel ()
		{
			return channel;
		}

		public virtual void setChannel (string channel)
		{
			this.channel = channel;
		}

		public virtual string getLabel ()
		{
			return label;
		}

		public virtual void setLabel (string label)
		{
			this.label = label;
		}

		public virtual string getComment ()
		{
			return comment;
		}

		public virtual void setComment (string comment)
		{
			this.comment = comment;
		}

		public virtual long getCreateTimestamp ()
		{
			return createTimestamp;
		}

		public virtual void setCreateTimestamp (long createTimestamp)
		{
			this.createTimestamp = createTimestamp;
		}

		public virtual long getExecutionTimestamp ()
		{
			return executionTimestamp;
		}

		public virtual void setExecutionTimestamp (long executionTimestamp)
		{
			this.executionTimestamp = executionTimestamp;
		}

		public virtual PositionCloseDetailsJson getPositionCloseDetails ()
		{
			return positionCloseDetails;
		}

		public virtual void setPositionCloseDetails (PositionCloseDetailsJson positionCloseDetails)
		{
			this.positionCloseDetails = positionCloseDetails;
		}

		public override string ToString ()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

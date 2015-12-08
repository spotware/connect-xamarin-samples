namespace OpenApiLib.Json
{
	public class SymbolJson
	{
		private string symbolName;

		private int digits;

		private int pipPosition;

		private string measurementUnits;

		private string baseAsset;

		private string quoteAsset;

		private bool tradeEnabled;

		private double tickSize;

		private string description;

		private int maxLeverage;

		private double swapLong;

		private double swapShort;

		private string threeDaysSwaps;

		private long minOrderVolume;

		private long minOrderStep;

		private long maxOrderVolume;

		private string assetClass;

		private double lastBid;

		private double lastAsk;

		public virtual string getSymbolName()
		{
			return symbolName;
		}

		public virtual void setSymbolName(string symbolName)
		{
			this.symbolName = symbolName;
		}

		public virtual int getDigits()
		{
			return digits;
		}

		public virtual void setDigits(int digits)
		{
			this.digits = digits;
		}

		public virtual int getPipPosition()
		{
			return pipPosition;
		}

		public virtual void setPipPosition(int pipPosition)
		{
			this.pipPosition = pipPosition;
		}

		public virtual string getMeasurementUnits()
		{
			return measurementUnits;
		}

		public virtual void setMeasurementUnits(string measurementUnits)
		{
			this.measurementUnits = measurementUnits;
		}

		public virtual string getBaseAsset()
		{
			return baseAsset;
		}

		public virtual void setBaseAsset(string baseAsset)
		{
			this.baseAsset = baseAsset;
		}

		public virtual string getQuoteAsset()
		{
			return quoteAsset;
		}

		public virtual void setQuoteAsset(string quoteAsset)
		{
			this.quoteAsset = quoteAsset;
		}

		public virtual bool getTradeEnabled()
		{
			return tradeEnabled;
		}

		public virtual void setTradeEnabled(bool tradeEnabled)
		{
			this.tradeEnabled = tradeEnabled;
		}

		public virtual double getTickSize()
		{
			return tickSize;
		}

		public virtual void setTickSize(double tickSize)
		{
			this.tickSize = tickSize;
		}

		public virtual string getDescription()
		{
			return description;
		}

		public virtual void setDescription(string description)
		{
			this.description = description;
		}

		public virtual int getMaxLeverage()
		{
			return maxLeverage;
		}

		public virtual void setMaxLeverage(int maxLeverage)
		{
			this.maxLeverage = maxLeverage;
		}

		public virtual long getMinOrderVolume()
		{
			return minOrderVolume;
		}

		public virtual void setMinOrderVolume(long minOrderVolume)
		{
			this.minOrderVolume = minOrderVolume;
		}

		public virtual long getMinOrderStep()
		{
			return minOrderStep;
		}

		public virtual void setMinOrderStep(long minOrderStep)
		{
			this.minOrderStep = minOrderStep;
		}

		public virtual long getMaxOrderVolume()
		{
			return maxOrderVolume;
		}

		public virtual void setMaxOrderVolume(long maxOrderVolume)
		{
			this.maxOrderVolume = maxOrderVolume;
		}

		public virtual double getSwapLong()
		{
			return swapLong;
		}

		public virtual void setSwapLong(double swapLong)
		{
			this.swapLong = swapLong;
		}

		public virtual double getSwapShort()
		{
			return swapShort;
		}

		public virtual void setSwapShort(double swapShort)
		{
			this.swapShort = swapShort;
		}

		public virtual string getThreeDaysSwaps()
		{
			return threeDaysSwaps;
		}

		public virtual void setThreeDaysSwaps(string threeDaysSwaps)
		{
			this.threeDaysSwaps = threeDaysSwaps;
		}

		public virtual string getAssetClass()
		{
			return assetClass;
		}

		public virtual void setAssetClass(string assetClass)
		{
			this.assetClass = assetClass;
		}

		public virtual double getLastAsk()
		{
			return lastAsk;
		}

		public virtual void setLastAsk(double lastAsk)
		{
			this.lastAsk = lastAsk;
		}

		public virtual double getLastBid()
		{
			return lastBid;
		}

		public virtual void setLastBid(double lastBid)
		{
			this.lastBid = lastBid;
		}
	}
}

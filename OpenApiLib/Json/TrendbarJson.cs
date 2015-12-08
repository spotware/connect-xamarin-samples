namespace OpenApiLib.Json
{
	public class TrendbarJson
	{
		private long timestamp;

		private double high;

		private double low;

		private double open;

		private double close;

		private long volume;

		public virtual long getTimestamp()
		{
			return timestamp;
		}

		public virtual double getHigh()
		{
			return high;
		}

		public virtual double getLow()
		{
			return low;
		}

		public virtual double getOpen()
		{
			return open;
		}

		public virtual double getClose()
		{
			return close;
		}

		public virtual long getVolume()
		{
			return volume;
		}

		public virtual void setTimestamp(long timestamp)
		{
			this.timestamp = timestamp;
		}

		public virtual void setHigh(double high)
		{
			this.high = high;
		}

		public virtual void setLow(double low)
		{
			this.low = low;
		}

		public virtual void setOpen(double open)
		{
			this.open = open;
		}

		public virtual void setClose(double close)
		{
			this.close = close;
		}

		public virtual void setVolume(long volume)
		{
			this.volume = volume;
		}

		public override string ToString()
		{
			return org.apache.commons.lang3.builder.ToStringBuilder.reflectionToString(this, 
				org.apache.commons.lang3.builder.ToStringStyle.SHORT_PREFIX_STYLE);
		}
	}
}

namespace OpenApiLib.Json
{
	public class TickDataJson
	{
		private long timestamp;

		private double tick;

		public virtual long getTimestamp()
		{
			return timestamp;
		}

		public virtual void setTimestamp(long timestamp)
		{
			this.timestamp = timestamp;
		}

		public virtual double getTick()
		{
			return tick;
		}

		public virtual void setTick(double tick)
		{
			this.tick = tick;
		}
	}
}

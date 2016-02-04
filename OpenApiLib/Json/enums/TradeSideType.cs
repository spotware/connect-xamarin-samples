namespace OpenApiLib.Json.Enums
{
	public sealed class TradeSideType
	{
		public static readonly TradeSideType BUY = new TradeSideType (1);
		public static readonly TradeSideType SELL = new TradeSideType (2);

		private readonly int id;

		internal TradeSideType (int id)
		{
			this.id = id;
		}

		public int getId ()
		{
			return this.id;
		}

		public TradeSideType getOpposite ()
		{
			return this == TradeSideType.BUY ? TradeSideType.SELL : TradeSideType.BUY;
		}

		public static TradeSideType valueOf (int id)
		{
			switch (id) {
			case 1:
				{
					return TradeSideType.BUY;
				}

			case 2:
				{
					return TradeSideType.SELL;
				}

			default:
				{
					throw new System.ArgumentException ("Unsupported trade side with id=" + id);
				}
			}
		}
	}
}

using Newtonsoft.Json;

namespace OpenApiLib.Json {
	public class TrendbarJson {
		private long timestamp;
		private double high;
		private double low;
		private double open;
		private double close;
		private long volume;

		public long Timestamp {
			get {
				return timestamp;
			}
			set {
				timestamp = value;
			}
		}

		public double High {
			get {
				return high;
			}
			set {
				high = value;
			}
		}

		public double Low {
			get {
				return low;
			}
			set {
				low = value;
			}
		}

		public double Open {
			get {
				return open;
			}
			set {
				open = value;
			}
		}


		public double Close {
			get {
				return close;
			}
			set {
				close = value;
			}
		}

		public long Volume {
			get {
				return volume;
			}
			set {
				volume = value;
			}
		}

		public override string ToString() {
			return JsonConvert.SerializeObject (this);
		}
	}
}

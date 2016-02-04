using Newtonsoft.Json;

namespace OpenApiLib.Json {
	public class TrendbarJson {
		public long Timestamp { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public double Open { get; set; }
		public double Close { get; set; }
		public long Volume { get; set; }

		public override string ToString() {
			return JsonConvert.SerializeObject (this);
		}
	}
}

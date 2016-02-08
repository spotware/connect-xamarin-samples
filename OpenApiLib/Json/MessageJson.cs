using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class MessageJson<T> : AbstractJson
	{
		public T Data { get; set; }
		public ErrorJson Error { get; set; }
	}
}

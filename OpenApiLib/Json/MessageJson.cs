using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class MessageJson<T>
	{
		private T data;
		private ErrorJson error;

		public static MessageJson<T> newInstance(T data)
		{
			return new MessageJson<T>(data);
		}

		public MessageJson()
		{
		}

		public MessageJson(T data)
		{
			this.Data = data;
		}

		public T Data { get; set; }
		public ErrorJson Error { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

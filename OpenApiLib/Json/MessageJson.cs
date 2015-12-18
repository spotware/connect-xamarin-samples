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
			this.data = data;
		}

		public T Data {
			get {
				return data;
			}
			set {
				data = value;
			}
		}

		public ErrorJson Error {
			get {
				return error;
			}
			set {
				error = value;
			}
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

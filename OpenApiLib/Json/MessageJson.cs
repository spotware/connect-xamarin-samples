using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class MessageJson<T>
	{
		private T data;

		private ErrorJson error;

		public MessageJson()
		{
		}

		public MessageJson(T data)
		{
			this.data = data;
		}

		public virtual T getData()
		{
			return data;
		}

		public virtual ErrorJson getError()
		{
			return error;
		}

		public virtual void setData(T data)
		{
			this.data = data;
		}

		public virtual void setError(ErrorJson error)
		{
			this.error = error;
		}

		public static MessageJson<T> newInstance<T>(T data)
		{
			return new MessageJson<T>(data);
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

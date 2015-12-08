using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class CursorMessageJson<T> : MessageJson<T>
	{
		private string next;

		public virtual string getNext()
		{
			return next;
		}

		public virtual void setNext(string next)
		{
			this.next = next;
		}

		public static CursorMessageJson<T> newInstance<T>(T data, string nextCursor)
		{
			CursorMessageJson<T> connectCursorMessage = new CursorMessageJson<T>();
			connectCursorMessage.Data = data;
			connectCursorMessage.setNext(nextCursor);
			return connectCursorMessage;
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

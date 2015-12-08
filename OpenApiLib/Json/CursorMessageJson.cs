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

		public static CursorMessageJson<T> newInstance<T>(T data, 
			string nextCursor)
		{
			CursorMessageJson<T> connectCursorMessage = new CursorMessageJson<T>();
			connectCursorMessage.setData(data);
			connectCursorMessage.setNext(nextCursor);
			return connectCursorMessage;
		}

		public override string ToString()
		{
			return new org.apache.commons.lang3.builder.ToStringBuilder(this, org.apache.commons.lang3.builder.ToStringStyle
				.SHORT_PREFIX_STYLE).appendSuper(base.ToString()).append("next", next).ToString(
				);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is CursorMessageJson))
			{
				return false;
			}
			CursorMessageJson<object> other = obj;
			return new org.apache.commons.lang3.builder.EqualsBuilder().appendSuper(base.Equals
				(obj)).append(next, other.next).isEquals();
		}

		public override int GetHashCode()
		{
			return new org.apache.commons.lang3.builder.HashCodeBuilder().appendSuper(base.GetHashCode
				()).append(next).toHashCode();
		}
	}
}

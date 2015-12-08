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
			return new org.apache.commons.lang3.builder.ToStringBuilder(this, org.apache.commons.lang3.builder.ToStringStyle
				.SHORT_PREFIX_STYLE).append("data", data).append("error", error).ToString();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is MessageJson))
			{
				return false;
			}
			com.mycompany.app.model.MessageJson<object> other = (com.mycompany.app.model.MessageJson
				)obj;
			return new org.apache.commons.lang3.builder.EqualsBuilder().append(data, other.data
				).append(error, other.error).isEquals();
		}

		public override int GetHashCode()
		{
			return new org.apache.commons.lang3.builder.HashCodeBuilder().append(data).append
				(error).toHashCode();
		}
	}
}

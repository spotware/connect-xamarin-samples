namespace OpenApiLib.Json
{
	public class ErrorJson
	{
		private readonly string errorCode;

		private readonly string description;

		public ErrorJson(string type, string message)
		{
			this.errorCode = type;
			this.description = message;
		}

		public virtual string getErrorCode()
		{
			return errorCode;
		}

		public virtual string getDescription()
		{
			return description;
		}

		public override string ToString()
		{
			return new org.apache.commons.lang3.builder.ToStringBuilder(this, org.apache.commons.lang3.builder.ToStringStyle
				.SHORT_PREFIX_STYLE).append("errorCode", errorCode).append("description", description
				).ToString();
		}
	}
}

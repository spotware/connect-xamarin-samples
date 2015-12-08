using Newtonsoft.Json;

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
			return JsonConvert.SerializeObject (this);
		}
	}
}

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
		public string ErrorCode 
		{
			get { return this.errorCode;}
		}

		public string Description
		{
			get { return this.description;}
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

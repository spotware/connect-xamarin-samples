using Newtonsoft.Json;

namespace OpenApiLib.Json
{
	public class ErrorJson : AbstractJson
	{
		public string ErrorCode { get; set; }
		public string Description { get; set; }
	}
}

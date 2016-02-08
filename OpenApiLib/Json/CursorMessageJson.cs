namespace OpenApiLib.Json
{
	public class CursorMessageJson<T> : MessageJson<T>
	{
		public string Next { get; set; }
	}
}

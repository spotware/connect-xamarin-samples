using System;

namespace OpenApiDeveloperLibrary.Json
{
	public class AccountsAPIException : System.Exception
	{
		private string code;

		private string message;

		public AccountsAPIException(string code, string message)
		{
			this.code = code;
			this.message = message;
		}

		public AccountsAPIException(Exception nested) : base(nested.Message, nested) {}

		public override string Message
		{
			get
			{
				return message;
			}
		}
	}
}

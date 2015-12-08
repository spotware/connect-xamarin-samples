namespace OpenApiLib.Json
{
	public class ProfileJson
	{
		private long userId;

		private string nickname;

		private string email;

		public virtual long getUserId()
		{
			return userId;
		}

		public virtual void setUserId(long userId)
		{
			this.userId = userId;
		}

		public virtual string getNickname()
		{
			return nickname;
		}

		public virtual void setNickname(string nickname)
		{
			this.nickname = nickname;
		}

		public virtual string getEmail()
		{
			return email;
		}

		public virtual void setEmail(string email)
		{
			this.email = email;
		}
	}
}

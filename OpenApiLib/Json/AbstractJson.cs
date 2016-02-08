using System;
using Newtonsoft.Json;

namespace OpenApiLib
{
	public abstract class AbstractJson
	{
		public override string ToString()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}


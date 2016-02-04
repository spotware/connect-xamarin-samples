using System;
using System.IO;
using ProtoBuf;

namespace OpenApiDeveloperLibrary
{
	public class Utils
	{
		public static byte[] Serialize<T>(T obj)
		{
			MemoryStream ms = new MemoryStream ();
			Serializer.Serialize<T> (ms, obj);
			return ms.ToArray ();
		}

		public static T Deserialize<T>(byte[] msg)
		{
			return Serializer.Deserialize<T> (new MemoryStream (msg));
		}
	}
}


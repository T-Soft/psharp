using System.Collections.Generic;

namespace Psharp.Core.Language.Parser3 {
	public static class KnownOptions
	{
		public static string Static = "static";
		public static string Dynamic = "dynamic";
		public static string Partial = "partial";
		public static string Locals = "locals";

		public static IEnumerable<string> GetOptionsList()
		{
			return new List<string>() {Static,Dynamic,Partial,Locals};
		}
	}
}

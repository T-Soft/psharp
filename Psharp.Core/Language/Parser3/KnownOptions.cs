using System.Collections.Generic;

namespace Sharpen.Core.Language.Parser3 {
	public static class KnownOptions
	{
		public static string Static = "static";
		public static string Dynamic = "dynamic";
		public static string Partial = "dynamic";
		public static string Locals = "dynamic";

		public static IEnumerable<string> GetOptionsList()
		{
			return new List<string>() {Static,Dynamic,Partial,Locals};
		}
	}
}

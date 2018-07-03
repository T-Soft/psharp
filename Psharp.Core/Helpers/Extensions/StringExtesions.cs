using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Helpers.Extensions {
	public static class StringExtesions {

		public static bool HasText(this string s)
		{
			return !string.IsNullOrEmpty(s.Trim());
		}
	}
}

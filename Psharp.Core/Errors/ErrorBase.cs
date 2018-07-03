using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Errors
{
	public abstract class ErrorBase
	{
		protected ErrorBase()
		{ }

		protected ErrorBase(string message, bool isWarning = false)
		{
			Message = message;
			IsWarning = isWarning;
		}

		public bool IsWarning { get; set; }
		public string Message { get; set; }

		public override string ToString() => Message;
	}
}

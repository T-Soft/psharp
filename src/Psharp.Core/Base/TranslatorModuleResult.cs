using System;
using Psharp.Core.Errors;

namespace Psharp.Core.Base
{
	public abstract class TranslatorModuleResult
	{
		public Error Error { set; get; }
		public bool Success => Error == null;

		protected TranslatorModuleResult(string message, bool isWarning = false)
		{
			Error = new Error(message, isWarning);
		}

		protected TranslatorModuleResult(Exception ex)
		{
			Error = new Error(ex);
		}

		protected TranslatorModuleResult(Error err)
		{
			Error = err;
		}

		protected TranslatorModuleResult()
		{ }
	}
}

using System;
using Sharpen.Core.Errors;
using Sharpen.Core.Parser;

namespace Sharpen.Core.Validator
{
	public class CodeValidatorResult: ICodeValidatorResult
	{
		public bool WasException => Exception != null;
		public bool WasError => Error != null;
		public bool IsValid => !(WasException || WasError);
		public Error Error { get; }
		public Exception Exception { get; }
		public ParseTree ValidatedParseTree { get; }

		public CodeValidatorResult(Exception ex)
		{
			Error = null;
			Exception = ex;
		}

		public CodeValidatorResult(Error err)
		{
			Error = err;
			Exception = null;
		}

		public CodeValidatorResult(ParseTree validatedTree)
		{
			Error = null;
			Exception = null;
			ValidatedParseTree = validatedTree;
		}

		public CodeValidatorResult(string message)
		{
			Exception = null;
			Error = new Error(message,false);
		}

		public CodeValidatorResult(bool success)
		{
			if (!success)
			{
				Error = new Error("Code validation failed");
			}
		}

		public CodeValidatorResult(){}
	}
}

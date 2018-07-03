using System;
using Sharpen.Core.Errors;

namespace Sharpen.Core.Generator.Text {
	public class CodeTextGeneratorResult : ICodeGeneratorResult
	{
		//public CodeCompileUnit Generated { get; }
		public string GeneratedCode {get;}
		public bool WasError => Error != null;

		public bool Success => !WasError;

		public Error Error { get; }
		
		public CodeTextGeneratorResult(CodeTextPartGenerationResult generated)
		{
			if (!generated.Context.Success)
			{
				Error = generated.Context.Errors;
			}
			else
			{
				GeneratedCode = generated.Body;
			}
		}

		public CodeTextGeneratorResult(Exception ex)
		{
			Error = new CodeGeneratorError(new Error(ex).Message,false);
		}
	}
}

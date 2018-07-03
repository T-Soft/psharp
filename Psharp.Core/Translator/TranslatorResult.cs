using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Errors;
using Sharpen.Core.Generator;
using Sharpen.Core.Validator;

namespace Sharpen.Core.Translator
{
	public class TranslatorResult
	{
		public string TranslatedSourceCode { get; }
		public Assembly CompiledAssembly { get; }
		public Error Error { get; }
		public bool WasError => Error != null;

		public TranslatorResult() {}

		public TranslatorResult(ICodeGeneratorResult generated)
		{
			if (!generated.Success)
			{
				Error = generated.Error;
			}
			else
			{

			}
		}

		public TranslatorResult(ICodeValidatorResult valr)
		{
			Error = valr.Error;
		}
	}
}

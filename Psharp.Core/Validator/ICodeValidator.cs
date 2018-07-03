using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Validator {
	public interface ICodeValidator : IDisposable
	{
		ICodeValidatorResult ValidateContent(ValidationType inputObjectType, params object[] input);
		ICodeValidatorResult ValidateSyntax();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Errors;
using Sharpen.Core.Parser;

namespace Sharpen.Core.Validator {
	public interface ICodeValidatorResult {
		Error Error {get;}
		ParseTree ValidatedParseTree {get;}
		Exception Exception {get;}
		bool IsValid { get; }
	}
}

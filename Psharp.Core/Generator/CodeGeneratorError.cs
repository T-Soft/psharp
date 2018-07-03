using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Errors;

namespace Sharpen.Core.Generator {
	public class CodeGeneratorError:Error
	{
		public CodeGeneratorError(string message, bool isWarning) : base(message, isWarning)
		{}
	}
}

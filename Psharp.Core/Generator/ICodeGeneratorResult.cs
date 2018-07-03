using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Errors;

namespace Sharpen.Core.Generator {
	public interface ICodeGeneratorResult 
	{
		string GeneratedCode { get; }
		bool Success { get; }
		Error Error {get;}
	}
}

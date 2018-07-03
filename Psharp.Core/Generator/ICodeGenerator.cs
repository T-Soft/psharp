using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Parser;

namespace Sharpen.Core.Generator
{
	public interface ICodeGenerator
	{
		ICodeGeneratorResult Genearte(ParseTree sourceCodeTree, string namespaceName = null);
	}
}

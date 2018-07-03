using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Language.Model {
	public class GeneratedProgram : LanguageEntity, ICodeGeneratingEntity {
		
		public LanguageEntityTable<Namespace> Namespaces = new LanguageEntityTable<Namespace>();
		
		public GeneratedProgram()
		{}

		public string GenerateCode()
		{
			throw new NotImplementedException();
		}
	}
}

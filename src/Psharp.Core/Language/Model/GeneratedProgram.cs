using System;

namespace Psharp.Core.Language.Model {
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

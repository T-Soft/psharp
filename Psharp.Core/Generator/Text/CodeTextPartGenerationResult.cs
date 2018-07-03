using System.CodeDom;
using System.Collections.Generic;
using Sharpen.Core.Language.Model;

namespace Sharpen.Core.Generator.Text {
	public class CodeTextPartGenerationResult
	{
		public IEnumerable<string> StatementList { get; }
		public string Body { get; }
		public LanguageEntity Construct { get; }
		public CodeTextGeneratorContext Context { get; }
		
		public static CodeTextPartGenerationResult FromContext(CodeTextGeneratorContext context)
		{
			return new CodeTextPartGenerationResult(context);
		}
		
		private CodeTextPartGenerationResult(CodeTextGeneratorContext context)
		{
			Context = context;
		}

		public CodeTextPartGenerationResult(IEnumerable<string> statements, CodeTextGeneratorContext context): this(context)
		{
			StatementList = statements;
		}

		public CodeTextPartGenerationResult(string body, CodeTextGeneratorContext context) : this(context)
		{
			Body = body;
		}

		public CodeTextPartGenerationResult(LanguageEntity languageConstruct, CodeTextGeneratorContext context) : this(context)
		{
			Construct = languageConstruct;
		}
	}
}

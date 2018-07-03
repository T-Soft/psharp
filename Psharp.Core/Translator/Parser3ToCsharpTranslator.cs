using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.ConsoleParameters;
using Sharpen.Core.Errors;
using Sharpen.Core.Generator;
using Sharpen.Core.Generator.Text;
using Sharpen.Core.Parser;
using Sharpen.Core.Processors;
using Sharpen.Core.Validator;
using P = Sharpen.Core.Parser.Parser;

namespace Sharpen.Core.Translator
{
	public class Parser3ToCsharpTranslator: ITranslator
	{
		private InputParameterInfo _parameters;
		private string _sourceCodeText;
		private ParseTree _pTree;

		#region [CTORs]
		public Parser3ToCsharpTranslator(InputParameterInfo inputParameters)
		{
			_parameters = inputParameters;
			_sourceCodeText = File.ReadAllText(_parameters.InputFilePath);
		}
		#endregion
		
		#region [: ITranslator]
		public void SetInputCode(string inputCode)
		{
			_sourceCodeText = inputCode;
		}

		public TranslatorResult Translate(TranslateTarget target)
		{
			Preprocessor preprocessor = new Preprocessor(_sourceCodeText);
			_sourceCodeText = preprocessor.Run();
			ICodeValidatorResult validatedTree;
			using (CodeValidator vld = new CodeValidator(_sourceCodeText))
			{
				validatedTree = vld.ValidateSyntax();
			}

			if (!validatedTree.IsValid)
			{
				return new TranslatorResult(validatedTree);
			}
			_pTree = validatedTree.ValidatedParseTree;

			//ICodeGenerator generator = new CodeDomGenerator();
			ICodeGenerator generator = new CodeTextGenerator();
			ICodeGeneratorResult generated = generator.Genearte(_pTree);

			Postprocessor postporocessor = new Postprocessor(generated);

			return new TranslatorResult(postporocessor.Run());
		}

		public CodeValidatorResult CodeIsValid()
		{
			try
			{
				ParseTree testParseTree = GetParseTree();
				if (testParseTree.Errors.Any()) {
					AggregateError err = 
						new AggregateError(
							testParseTree.Errors
								.Select(pe=>new Error($"{pe.Message}->({pe.Line},{pe.Column})"))
						);
					return new CodeValidatorResult(err);
				}
				return new CodeValidatorResult(testParseTree);
			}
			catch (Exception ex) {
				return new CodeValidatorResult(ex);
			}
		}
		#endregion

		private ParseTree GetParseTree()
		{
			P parser = new P(new Scanner());
			return parser.Parse(_sourceCodeText);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Errors;
using Sharpen.Core.Generator;
using Sharpen.Core.Generator.Text;
using Sharpen.Core.Language;
using Sharpen.Core.Language.Parser3;
using Sharpen.Core.Parser;

namespace Sharpen.Core.Validator {
	public enum ValidationType
	{
		OptionsDirectiveParameters,
		MainFunctionPresent
	}
	public class CodeValidator : ICodeValidator
	{
		private readonly string _sourceCode;

		#region [CTOR & :IDisposable]
		public CodeValidator(string sourceCode)
		{
			_sourceCode = sourceCode;
		}

		public CodeValidator()
		{}

		public void Dispose()
		{}

		#endregion

		#region [Public methods]
		public ICodeValidatorResult ValidateContent(ValidationType inputObjectType, params object[] input )
		{
			bool ret = false;
			switch (inputObjectType)
			{
				case ValidationType.OptionsDirectiveParameters:
					return ValidateOptionsDirective((List<string>) input[0]);
				case ValidationType.MainFunctionPresent:
					return ValidateMainFunctionPresence((List<ParseNode>)input[0],(CodeTextGeneratorContext)input[1]);
				default:
					return new CodeValidatorResult("Unknown validator request.");
			}
		}

		public ICodeValidatorResult ValidateSyntax()
		{
			Parser.Parser parser = new Parser.Parser(new Scanner());
			try
			{
				ParseTree testParseTree = parser.Parse(_sourceCode);
				if (testParseTree.Errors.Any())
				{
					AggregateError err =
						new AggregateError(
							testParseTree.Errors
								.Select(pe => new Error($"{pe.Message}->({pe.Line},{pe.Column})"))
						);
					return new CodeValidatorResult(err);
				}
				return new CodeValidatorResult(testParseTree);
			}
			catch (Exception ex)
			{
				return new CodeValidatorResult(ex);
			}
		}
		#endregion

		#region [Validations logic]
		private CodeValidatorResult ValidateOptionsDirective(IEnumerable<string> options)
		{
			List<string> knownOptions = Language.Parser3.KnownOptions.GetOptionsList().ToList();
			StringBuilder unknownOptions = new StringBuilder();

			foreach (var opt in options)
			{
				if (!knownOptions.Contains(opt))
				{
					unknownOptions.Append($"{opt},");
				}
			}
			return unknownOptions.Length != 0
				? new CodeValidatorResult($"Unknown option(s) found : {unknownOptions.ToString().Trim(',')}")
				: new CodeValidatorResult();
		}

		private CodeValidatorResult ValidateMainFunctionPresence(IEnumerable<ParseNode> functionDefinitions,CodeTextGeneratorContext context)
		{
			if (context.IsStatic)
			{
				return new CodeValidatorResult();
			}

			IEnumerable<string> functionNames =
				functionDefinitions
				.Select(fd => fd.GetChildOfTokenType(TokenType.FunctionName)
								.GetChildOfTokenType(TokenType.IDENTIFIER)
								.Text());

			if (!functionNames.Contains(Constants.MainFunctionName))
			{
				return new CodeValidatorResult("<main> method not found");
			}
			return new CodeValidatorResult();
		}

		#endregion
	}
}

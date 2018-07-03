using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;
using Sharpen.Core.Errors;
using Sharpen.Core.Language.Model;
using Sharpen.Core.Parser;
using Sharpen.Core.Validator;

namespace Sharpen.Core.Generator.Text {
	public class CodeTextGeneratorContext 
	{
		public ICodeValidator Validator { get; }
		public string NamespaceName { get; }


		public AggregateError Errors => new AggregateError(_errors);
		public bool Success => !_errors.Any();
		public bool IsStatic
		{
			get { return _isStatic; }
			set { _isStatic = value; }
		}
		public bool Locals
		{
			get { return _locals; }
			set { _locals = value; }
		}

		private readonly List<string> _usedNamespaces = new List<string>();
		private readonly List<Error> _errors = new List<Error>();

		private bool _isStatic = false;
		private bool _locals = false;

		public readonly LanguageEntityTable<Variable> GlobalVariables = new LanguageEntityTable<Variable>();
		public readonly LanguageEntityTable<Method> Methods = new LanguageEntityTable<Method>();
		
		// NOTE:------------------------------------------------ code generation parameters
		public ParseNode AssignmentLeftPartVariableNode { set; get; } = null;
		public string GeneratingMethodName { set; get; } = null;
		public Class GeneratingClass { set; get; } = null;
		public bool AssignmentBodyIsStringOrHash { set; get; } = false;
		// NOTE:------------------------------------------------ code generation parameters

		public CodeTextGeneratorContext(string namespaceName)
		{
			NamespaceName = namespaceName;
			Validator = new CodeValidator();
		}

		#region [Add error / warning]
		public void AddError(string errorMessage)
		{
			_errors.Add(new CodeGeneratorError(errorMessage,false));
		}

		public void AddWarning(string warningMessage)
		{
			_errors.Add(new CodeGeneratorError(warningMessage, true));
		}
		#endregion
		
	}
}

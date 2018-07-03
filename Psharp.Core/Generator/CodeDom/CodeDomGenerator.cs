using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sharpen.Core.Errors;
using Sharpen.Core.Helpers.Extensions;
using Sharpen.Core.Language.Model;
using Sharpen.Core.Language.Parser3;
using Sharpen.Core.Parser;
using Sharpen.Core.Validator;
/*
namespace Sharpen.Core.Generator.CodeDom
{
	public class CodeDomGenerator:ICodeGenerator
	{
		private CodeGeneratorContext _partialContext;
		
		public CodeGeneratorResult Genearte(ParseTree sourceCodeTree, string namespaceName = null)
		{
			CodePartGenerationResult generated = null;
			try
			{
				generated = Generate(sourceCodeTree, new CodeGeneratorContext(namespaceName));
				
			}
			catch (Exception ex)
			{
				if (_partialContext != null)
				{
					_partialContext.AddError(new Error(ex).Message);
					return new CodeGeneratorResult(CodePartGenerationResult.FromContext(_partialContext));
				}
				else
				{
					return new CodeGeneratorResult(ex);
				}
			}
			return new CodeGeneratorResult(generated);
		}

		#region [Token type switch]
		private CodePartGenerationResult Generate(ParseNode node, CodeGeneratorContext context)
		{
			CodePartGenerationResult gen = null;
			
			switch(node.Token.Type) {
				case TokenType.Start:
					gen = GenerateStart(node, context);
					break;
				case TokenType.FunctionDefinition:
					gen = GenerateFunctionDefinition(node, context);
					break;
				case TokenType.Body:
					gen = GenerateBody(node, context);
					break;
				case TokenType.Literal:
					gen = GenerateLiteral(node, context);
					break;
				
				case TokenType.LocalVariables:
					gen = GenerateLocalVariables(node, context);
					break;
				
				case TokenType.Call:
					gen = GenerateCall(node, context);
					break;
				case TokenType.Function:
					gen = GenerateFunction(node, context);
					break;
				case TokenType.FullFunctionName:
					gen = GenerateFullFunctionName(node, context);
					break;
				case TokenType.StaticPrefix:
					gen = GenerateStaticPrefix(node, context);
					break;
				case TokenType.InstancePrefix:
					gen = GenerateInstancePrefix(node, context);
					break;
				case TokenType.ConstructorPrefix:
					gen = GenerateConstructorPrefix(node, context);
					break;
				case TokenType.EvalConstruct:
					gen = GenerateEvalConstruct(node, context);
					break;
				case TokenType.EvalBody:
					gen = GenerateEvalBody(node, context);
					break;
				case TokenType.FormatString:
					gen = GenerateFormatString(node, context);
					break;
				case TokenType.WhileCycle:
					gen = GenerateWhileCycle(node, context);
					break;
				case TokenType.WhileCondition:
					gen = GenerateWhileCondition(node, context);
					break;
				case TokenType.WhileBody:
					gen = GenerateWhileBody(node, context);
					break;
				case TokenType.CycleSeparator:
					gen = GenerateCycleSeparator(node, context);
					break;
				case TokenType.BoolCondition:
					gen = GenerateBoolCondition(node, context);
					break;
				case TokenType.ForCycle:
					gen = GenerateForCycle(node, context);
					break;
				case TokenType.ForCounter:
					gen = GenerateForCounter(node, context);
					break;
				case TokenType.ForFrom:
					gen = GenerateForFrom(node, context);
					break;
				case TokenType.ForTo:
					gen = GenerateForTo(node, context);
					break;
				case TokenType.ForBody:
					gen = GenerateForBody(node, context);
					break;
				case TokenType.IfCondition:
					gen = GenerateIfCondition(node, context);
					break;
				case TokenType.IfTrueBranch:
					gen = GenerateIfTrueBranch(node, context);
					break;
				case TokenType.IfFalseBranch:
					gen = GenerateIfFalseBranch(node, context);
					break;
				case TokenType.Assignment:
					gen = GenerateAssignment(node, context);
					break;
				case TokenType.AssignmentBody:
					gen = GenerateAssignmentBody(node, context);
					break;
				case TokenType.HashAssignment:
					gen = GenerateHashAssignment(node, context);
					break;
				case TokenType.Key:
					gen = GenerateKey(node, context);
					break;
				case TokenType.VariablesDefinitions:
					gen = GenerateVariablesDefinitions(node, context);
					break;
				case TokenType.ParamsDefinitions:
					gen = GenerateParamsDefinitions(node, context);
					break;
				case TokenType.Params:
					gen = GenerateParams(node, context);
					break;
				case TokenType.Param:
					gen = GenerateParam(node, context);
					break;
				case TokenType.PLAIN:
					gen = GeneratePlainText(node, context);
					break;
				case TokenType.Variable:
					gen = GenerateVariable(node, context);
					break;
				default:
					// TODO: throw CodeGeneratorException (or error?) here
					throw new Exception($"Unknown token! {node.Token.Text}");
			}
			return gen;
		}
		#endregion

		#region [Parts generation methods]
		
		private CodePartGenerationResult GenerateParam(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateParams(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateParamsDefinitions(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateVariablesDefinitions(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateKey(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateHashAssignment(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateAssignmentBody(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		
		private CodePartGenerationResult GenerateIfFalseBranch(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateIfTrueBranch(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateIfCondition(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateForBody(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateForTo(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateForFrom(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateForCounter(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateForCycle(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateBoolCondition(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateCycleSeparator(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateWhileBody(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateWhileCondition(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateWhileCycle(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateFormatString(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateEvalBody(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateEvalConstruct(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateConstructorPrefix(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateInstancePrefix(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateStaticPrefix(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateFullFunctionName(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateFunction(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodePartGenerationResult GenerateCall(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		
		private CodePartGenerationResult GenerateLocalVariables(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		
		private CodePartGenerationResult GenerateLiteral(ParseNode node, CodeGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		private CodePartGenerationResult GenerateVariable(ParseNode node, CodeGeneratorContext context) {
			// means that variable should be printed out
			// NOTE: simply add call to a method IOutput.Print() and pass variable to it
			// TODO: implement IOutput.Print() and reference it in generated code
			throw new NotImplementedException();
		}
		private CodePartGenerationResult GeneratePlainText(ParseNode node, CodeGeneratorContext context) {
			// NOTE: simply add call to a method IOutput.Print() and pass content to it
			// TODO: implement IOutput.Print() and reference it in generated code

			//NOTE : don't generate code if node content is empty

			string content = node.Text();
			if (content.HasText())
			{
				//generate
			}
			else
			{
				// don't generate 
			}
			return new CodePartGenerationResult(new CodeAssignStatement(), context);

			//throw new NotImplementedException();
		}

		/// <remarks>AssignmentBody	-> ((INTEGER | DOUBLE | STRING | (CF Function) | Variable) (MathOp (INTEGER | DOUBLE | STRING | (CF Function) | Variable))*)| BOOLVALUE | HashAssignment+;</remarks>
		private CodePartGenerationResult GenerateAssignment(ParseNode node, CodeGeneratorContext context)
		{
			// NOTE: variable can have multiple parts (i.e. have classes, fields, static classes)
			Variable variableToAssignTo = new Variable(context.AssignmentLeftPartVariableNode);
			CodeExpression leftPart;

			//1) search variable in local variables
			// if function local variables contain this variable - check if it's lready declared
			// if not declared - declare
			//2) search variable in function parameters
			//3) search global field
			//if present - use it
			//if is not present - generate it and use

			Method gen = context.Methods[context.GeneratingMethodName];
			if (gen.LocalVariables.Contains(variableToAssignTo.Name))
			{
				//means we are referencing local variable here

			}
			else
			{
				if (gen.InputParameters.Contains(variableToAssignTo.Name))
				{
					//means input parameter
				}
				else
				{
					// global field
					//search in the generated class
					// if found - use
					// if not - generate and use
				}
			}


			// if function local vars don't contain this variable - it's global field
			if (variableToAssignTo.IsField)
			{
				if (variableToAssignTo.IsStatic)
				{
					leftPart = new CodeFieldReferenceExpression(
						new CodeTypeReferenceExpression(variableToAssignTo.ClassName),
						variableToAssignTo.Name);
				}
				// variable can be a part of the hash or object $var.field[]
				
				leftPart = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), variableToAssignTo.Name);
			}
			else
			{
				// means we are using local variable

				// search variable name in context.localvariables
				// if found use it
				// if not - create variable declaration
				leftPart = new CodeVariableReferenceExpression(variableToAssignTo.Name);
			}

			CodeExpression rightPart;
			
			//CodeAssignStatement assignment = new CodeAssignStatement(leftPart,rightPart);
			//return new CodePartGenerationResult(assignment,context);
			throw new NotImplementedException();
		}

		/// <remarks>Body-> (Call | Variable (Assignment?) | PLAIN)+;</remarks>
		private CodePartGenerationResult GenerateBody(ParseNode node, CodeGeneratorContext context)
		{
			var statementNodes = node.Nodes;

			List<CodePartGenerationResult> innerGen = new List<CodePartGenerationResult>();

			// gather assignments
			for(int i = 0; i < statementNodes.Count; i++)
			{
				ParseNode statementNode = statementNodes[i];

				if (statementNode.Token.Type == TokenType.Variable)
				{
					if(statementNodes.NextNodeTokenType(i) == TokenType.Assignment)
					{
						context.AssignmentLeftPartVariableNode = statementNode;
						continue;
					} 
				}
				innerGen.Add(Generate(statementNode, context));
			}
			List<CodeStatement> generatedStatements = new List<CodeStatement>();
			innerGen.Aggregate(generatedStatements, (acc, genResult) => {
				acc.AddRange(genResult.Statements);
				return acc;
			});

			return new CodePartGenerationResult(generatedStatements,context);
		}

		private CodePartGenerationResult GenerateFunctionDefinition(ParseNode node, CodeGeneratorContext context) {
			//TODO: check that function has a body!

			string functionName = node.GetChildOfTokenType(TokenType.FunctionName).IdentifierString();
			
			// 00) gather input parameters
			List<string> inputParameters =
				node
					.GetChildOfTokenType(TokenType.ParamsDefinitions)?
					.IdentifierStringCollection()
					.ToList();

			// 0) gather local variables
			List<string> localVariables = 
				node
					.GetChildOfTokenType(TokenType.LocalVariables)?
					.GetChildOfTokenType(TokenType.VariablesDefinitions)
					.IdentifierStringCollection()
					.ToList();

			ParseNode bodyDefinition = node.GetChildOfTokenType(TokenType.Body);

			Method generatedMethod = new Method(functionName);
			generatedMethod.LocalVariables.AddRange(localVariables?.Select(varname => new Variable(varname)));
			generatedMethod.InputParameters.AddRange(inputParameters?.Select(varname => new Variable(varname)));
			context.Methods.Add(generatedMethod);

			CodeMemberMethod csMethod = new CodeMemberMethod() {
				Name = functionName,
				Attributes = MemberAttributes.Public,
				ReturnType = new CodeTypeReference(typeof(object))
			};

			// for lower level generation steps checks
			context.GeneratingMethodName = functionName;

			// generate method body statements
			csMethod.Statements.AddRange(GenerateBody(bodyDefinition,context).Statements.ToArray());

			context.GeneratingMethodName = null;

			return new CodePartGenerationResult(csMethod,context);
		}

		private CodePartGenerationResult GenerateStart(ParseNode node, CodeGeneratorContext context) {
			ParseNode start = node.Nodes.First(); // skip ROOT node
			CodeValidatorResult v;

			CodeTypeDeclaration generatedClass = new CodeTypeDeclaration(Language.CSharp.Defaults.GeneratedClassName);
			CodeCompileUnit generated = new CodeCompileUnit();
			CodeNamespace generatedNs = !string.IsNullOrEmpty(context.NamespaceName)
				? new CodeNamespace(context.NamespaceName)
				: new CodeNamespace(Language.CSharp.Defaults.GeneratedNamespaceName);
			generated.Namespaces.Add(generatedNs);
			
			#region [Generate directives]
			ParseNode classDirective = start.GetChildOfTokenType(TokenType.ClassDirective);
			ParseNode useDirective = start.GetChildOfTokenType(TokenType.UseDirective);
			ParseNode optionsDirective = start.GetChildOfTokenType(TokenType.OptionsDirective);
			ParseNode baseDirective = start.GetChildOfTokenType(TokenType.BaseDirective);

			if(classDirective != null) {
				generatedClass = new CodeTypeDeclaration(classDirective.GetChildOfTokenType(TokenType.IDENTIFIER).Text());
			}
			generatedClass.TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed;

			if(useDirective != null) {
				context.AddError("@USE directive is not supported");
				StopGenerating(context);
			}

			if (optionsDirective != null)
			{
				IEnumerable<string> options = optionsDirective.GetChildrenOfTokenType(TokenType.IDENTIFIER).ToStringCollection();
				if (options != null)
				{
					v = context.Validator.ValidateContent(ValidationType.OptionsDirectiveParameters, options);
					if (!v.IsValid)
					{
						context.AddError(v.Error.Message);
						StopGenerating(context);
					}

					if (options.Contains(KnownOptions.Static))
					{
						
						//see http://stackoverflow.com/a/6308395
						//CodeDom does not support static classes, so what's next is a dirty workaround
						
						//NOTE: for now static classes are not generated
						//generatedClass.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "\nstatic"));
						//generatedClass.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, String.Empty));
						context.IsStatic = true;
					}
					if (options.Contains(KnownOptions.Dynamic))
					{
						// do nothing : all generated non static classes are dynamic by default
					}
					if (options.Contains(KnownOptions.Partial))
					{
						context.AddError("<partial> option is not supported");
						StopGenerating(context);
					}
					if (options.Contains(KnownOptions.Locals))
					{
						context.Locals = true;
					}
				}
			}

			if (baseDirective != null)
			{
				context.AddError("@BASE directive is not supported");
				StopGenerating(context);
			}
			#endregion
			
			// get function definitions
			IEnumerable<ParseNode> functionDefs = start.GetChildrenOfTokenType(TokenType.FunctionDefinition);
			v = context.Validator.ValidateContent(ValidationType.MainFunctionPresent, functionDefs, context);
			if (!v.IsValid)
			{
				context.AddError(v.Error.Message);
				StopGenerating(context);
			}

			//context.GeneratingClass = generatedClass;

			foreach (ParseNode func in functionDefs)
			{
				// generate methods
				CodeMemberMethod method = (CodeMemberMethod)Generate(func, context).Construct;
				generatedClass.Members.Add(method);
			}
			generatedNs.Types.Add(generatedClass);

			return new CodePartGenerationResult(generated,context);
		}
		#endregion

		public void StopGenerating(CodeGeneratorContext context)
		{
			_partialContext = context;
			throw new Exception("Generation stopped at critical error");
		}
	}
}
*/
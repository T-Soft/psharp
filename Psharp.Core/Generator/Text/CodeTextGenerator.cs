using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Core.Errors;
using Sharpen.Core.Helpers.Extensions;
using Sharpen.Core.Language.Model;
using Sharpen.Core.Language.Parser3;
using Sharpen.Core.Parser;
using Sharpen.Core.Validator;

namespace Sharpen.Core.Generator.Text
{
	public sealed class CodeTextGenerator:ICodeGenerator
	{
		private CodeTextGeneratorContext _partialContext;
		
		public ICodeGeneratorResult Genearte(ParseTree sourceCodeTree, string namespaceName = null)
		{
			CodeTextPartGenerationResult generated = null;
			try
			{
				generated = Generate(sourceCodeTree, new CodeTextGeneratorContext(namespaceName));
				
			}
			catch (Exception ex)
			{
				if (_partialContext != null)
				{
					_partialContext.AddError(new Error(ex).Message);
					return new CodeTextGeneratorResult(CodeTextPartGenerationResult.FromContext(_partialContext));
				}
				else
				{
					return new CodeTextGeneratorResult(ex);
				}
			}
			return new CodeTextGeneratorResult(generated);
		}

		#region [Token type switch]
		private CodeTextPartGenerationResult Generate(ParseNode node, CodeTextGeneratorContext context)
		{
			CodeTextPartGenerationResult gen = null;
			
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
		
		private CodeTextPartGenerationResult GenerateParam(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateParams(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateParamsDefinitions(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateVariablesDefinitions(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateKey(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		
		private CodeTextPartGenerationResult GenerateIfFalseBranch(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateIfTrueBranch(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateIfCondition(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateForBody(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateForTo(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateForFrom(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateForCounter(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateForCycle(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateBoolCondition(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateCycleSeparator(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateWhileBody(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateWhileCondition(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateWhileCycle(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateFormatString(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateEvalBody(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateEvalConstruct(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateConstructorPrefix(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateInstancePrefix(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateStaticPrefix(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateFullFunctionName(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateFunction(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateCall(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		
		private CodeTextPartGenerationResult GenerateLocalVariables(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		
		private CodeTextPartGenerationResult GenerateLiteral(ParseNode node, CodeTextGeneratorContext context)
		{
			throw new NotImplementedException();
		}
		private CodeTextPartGenerationResult GenerateVariable(ParseNode node, CodeTextGeneratorContext context) {
			// means that variable should be printed out
			// NOTE: simply add call to a method IOutput.Print() and pass variable to it
			// TODO: implement IOutput.Print() and reference it in generated code
			throw new NotImplementedException();
		}
		private CodeTextPartGenerationResult GeneratePlainText(ParseNode node, CodeTextGeneratorContext context) {
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
			return new CodeTextPartGenerationResult(string.Empty, context);

			//throw new NotImplementedException();
		}

		private CodeTextPartGenerationResult GenerateHashAssignment(ParseNode node, CodeTextGeneratorContext context) {
			// NOTE returns one '[key] = value' string
			string keyName = node.GetChildOfTokenType(TokenType.Key).IdentifierString();
			CodeTextPartGenerationResult value = Generate(node.GetChildOfTokenType(TokenType.AssignmentBody), context);
			throw new NotImplementedException();
		}

		/// <remarks>AssignmentBody	-> ((INTEGER | DOUBLE | STRING | (CF Function) | Variable) (MathOp (INTEGER | DOUBLE | STRING | (CF Function) | Variable))*)| BOOLVALUE | HashAssignment+;</remarks>
		private CodeTextPartGenerationResult GenerateAssignmentBody(ParseNode node, CodeTextGeneratorContext context) {
			// NOTE: should only return one statement or returns List<string> of '[key] = value' strings from GenerateHashAssignment() method

			if (node.Nodes.First().OfTokenType(TokenType.HashAssignment))
			{
				List<string> hashAssignments = new List<string>();
				foreach (ParseNode hashAssignment in node.GetChildrenOfTokenType(TokenType.HashAssignment))
				{
					hashAssignments.Add(Generate(hashAssignment, context).Body); 
				}
				return new CodeTextPartGenerationResult(hashAssignments,context);
			}
			// generate normal one statement assignment (function call / literal / other variable)
			// NOTE: consider different bracket types
			
			switch (node.Nodes.First().Token.Type)
			{
				case TokenType.INTEGER:
				case TokenType.STRING:
				case TokenType.BOOLVALUE:
				case TokenType.DOUBLE:
				case TokenType.Variable:
				case TokenType.CF:
					throw new NotImplementedException();
			}
			throw new NotImplementedException();
		}

		/// <remarks>Assignment	-> (BRACKETOPEN | PARENOPEN) AssignmentBody (BRACKETCLOSE | PARENCLOSE);</remarks>
		private CodeTextPartGenerationResult GenerateAssignment(ParseNode node, CodeTextGeneratorContext context)
		{
			// NOTE: returns declaration and assignment or just assignment
			Variable variableToAssignTo = new Variable(context.AssignmentLeftPartVariableNode);

			//1) search variable in local variables
			// if function local variables contain this variable - check if it's already declared
			// if not declared - declare
			//2) search variable in function parameters
			//3) search global field
			// if present - use it
			// if is not present - generate it and use
			List<string> generatedStatements = new List<string>();

			Method gen = context.Methods[context.GeneratingMethodName];
			if (gen.LocalVariables.Contains(variableToAssignTo.Name))
			{
				Variable localVariable = gen.LocalVariables[variableToAssignTo.Name];
				if (!localVariable.IsDeclared)
				{
					generatedStatements.Add(localVariable.Declare());
				}
			}
			else
			{
				if (!gen.InputParameters.Contains(variableToAssignTo.Name))
				{
					//means not an input parameter
					// then -> global field
					// search in the generated class
					// if not found - generate and use
					if(!context.GeneratingClass.Fields.Contains(variableToAssignTo.Name)) {
						context.GeneratingClass.Fields.Add(variableToAssignTo);
					}
				}
			}
			string leftPart = variableToAssignTo.GenerateCode();
			ParseNode assignmentBody = node.GetChildOfTokenType(TokenType.AssignmentBody);
			context.AssignmentBodyIsStringOrHash = node.Nodes.First().OfTokenType(TokenType.BRACKETOPEN);
			CodeTextPartGenerationResult rightPart = Generate(assignmentBody, context);

			// note: there's a difference between hash assignment and a simple assignment since hash is a dictionary
			if(assignmentBody.Nodes.First().OfTokenType(TokenType.HashAssignment))
			{
				// generate update dictionary code
				// .Add() or []= syntax
			}else
			{
				// generate normal assignment (function call / literal / other variable)
				generatedStatements.Add($"{leftPart}={rightPart.Body};");
			}
			
			throw new NotImplementedException();
		}

		/// <remarks>Body-> (Call | Variable (Assignment?) | PLAIN)+;</remarks>
		private CodeTextPartGenerationResult GenerateBody(ParseNode node, CodeTextGeneratorContext context)
		{
			var statementNodes = node.Nodes;

			List<CodeTextPartGenerationResult> innerGen = new List<CodeTextPartGenerationResult>();

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
			List<string> generatedStatements = new List<string>();
			
			innerGen.Aggregate(generatedStatements, (acc, genResult) => {
				acc.AddRange(genResult.StatementList);
				return acc;
			});

			return new CodeTextPartGenerationResult(generatedStatements,context);
		}

		private CodeTextPartGenerationResult GenerateFunctionDefinition(ParseNode node, CodeTextGeneratorContext context) {
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
			generatedMethod.ReturnType = DataType.Unknown;
			context.Methods.Add(generatedMethod);
			
			// for lower level generation steps checks
			context.GeneratingMethodName = functionName;
			
			// generate method body statements
			generatedMethod.Statements.AddRange(Generate(bodyDefinition,context).StatementList);
			
			context.GeneratingMethodName = null;

			return new CodeTextPartGenerationResult(generatedMethod,context);
		}

		private CodeTextPartGenerationResult GenerateStart(ParseNode node, CodeTextGeneratorContext context) {
			ParseNode start = node.Nodes.First(); // skip ROOT node
			ICodeValidatorResult v;
			GeneratedProgram generatedProgram = new GeneratedProgram();

			Namespace generatedNs = !string.IsNullOrEmpty(context.NamespaceName)
				? new Namespace(context.NamespaceName)
				: new Namespace(Language.CSharp.Defaults.GeneratedNamespaceName);

			generatedProgram.Namespaces.Add(generatedNs);
			
			#region [Generate P3 directives]
			ParseNode classDirective = start.GetChildOfTokenType(TokenType.ClassDirective);
			ParseNode useDirective = start.GetChildOfTokenType(TokenType.UseDirective);
			ParseNode optionsDirective = start.GetChildOfTokenType(TokenType.OptionsDirective);
			ParseNode baseDirective = start.GetChildOfTokenType(TokenType.BaseDirective);

			Class generatedClass = classDirective != null
				? new Class(classDirective.GetChildOfTokenType(TokenType.IDENTIFIER).Text())
				: new Class(Language.CSharp.Defaults.GeneratedClassName);
			
			if(useDirective != null) {
				// TODO: implement USE directive
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
						//NOTE: for now static classes are not generated
						context.IsStatic = true;
					}
					if (options.Contains(KnownOptions.Dynamic))
					{
						// do nothing : all generated non static classes are dynamic by default
					}
					if (options.Contains(KnownOptions.Partial))
					{
						generatedClass.IsPartial = true;
					}
					if (options.Contains(KnownOptions.Locals))
					{
						context.Locals = true;
					}
				}
			}

			if (baseDirective != null)
			{
				generatedClass.BaseClassName = baseDirective.GetChildOfTokenType(TokenType.IDENTIFIER).Text();
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
			context.GeneratingClass = generatedClass;
			foreach (ParseNode func in functionDefs)
			{
				// generate methods
				Method method = (Method) Generate(func, context).Construct;
				generatedClass.Methods.Add(method);
			}
			generatedNs.Classes.Add(generatedClass);
			context.GeneratingClass = null;
			
			return new CodeTextPartGenerationResult(generatedProgram,context);
		}
		#endregion

		public void StopGenerating(CodeTextGeneratorContext context)
		{
			_partialContext = context;
			throw new Exception("Generation stopped at critical error");
		}
	}
}

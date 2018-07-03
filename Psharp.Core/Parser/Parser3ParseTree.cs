using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Parser
{
	public class Parser3ParseTree: ParseTree
	{
		Parser3ParseTree() : base() {}

		protected override object EvalStart(ParseTree tree, params object[] paramlist)
		{
			return "Could not interpret input; no semantics implemented.";
		}

		protected override object EvalUseDirective(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalClassDirective(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalBaseDirective(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalOptionsDirective(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalVariable(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalFieldName(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalLiteral(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalFunctionDefinition(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalLocalVariables(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalBody(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalCall(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalFunction(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalFullFunctionName(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalStaticPrefix(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalInstancePrefix(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalConstructorPrefix(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalEvalConstruct(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalEvalBody(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalFormatString(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalWhileCycle(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalWhileCondition(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalWhileBody(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalCycleSeparator(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalBoolCondition(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalForCycle(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalForCounter(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalForFrom(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalForTo(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalForBody(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalIfCondition(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalIfTrueBranch(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalIfFalseBranch(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalAssignment(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalAssignmentBody(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalHashAssignment(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalKey(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalVariablesDefinitions(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalParamsDefinitions(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalParams(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}

		protected override object EvalParam(ParseTree tree, params object[] paramlist)
		{
			throw new NotImplementedException();
		}
	}
}

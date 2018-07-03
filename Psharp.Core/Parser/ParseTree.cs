// Generated by TinyPG v1.3 available at www.codeproject.com

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpen.Core.Parser
{
    #region ParseTree
    [Serializable]
    public class ParseErrors : List<ParseError>
    {
    }

    [Serializable]
    public class ParseError
    {
        private string message;
        private int code;
        private int line;
        private int col;
        private int pos;
        private int length;

        public int Code { get { return code; } }
        public int Line { get { return line; } }
        public int Column { get { return col; } }
        public int Position { get { return pos; } }
        public int Length { get { return length; } }
        public string Message { get { return message; } }

        // just for the sake of serialization
        public ParseError()
        {
        }

        public ParseError(string message, int code, ParseNode node) : this(message, code,  0, node.Token.StartPos, node.Token.StartPos, node.Token.Length)
        {
        }

        public ParseError(string message, int code, int line, int col, int pos, int length)
        {
            this.message = message;
            this.code = code;
            this.line = line;
            this.col = col;
            this.pos = pos;
            this.length = length;
        }
    }

    // rootlevel of the node tree
    [Serializable]
    public partial class ParseTree : ParseNode
    {
        public ParseErrors Errors;

        public List<Token> Skipped;

        public ParseTree() : base(new Token(), "ParseTree")
        {
            Token.Type = TokenType.Start;
            Token.Text = "Root";
            Errors = new ParseErrors();
        }

        public string PrintTree()
        {
            StringBuilder sb = new StringBuilder();
            int indent = 0;
            PrintNode(sb, this, indent);
            return sb.ToString();
        }

        private void PrintNode(StringBuilder sb, ParseNode node, int indent)
        {
            
            string space = "".PadLeft(indent, ' ');

            sb.Append(space);
            sb.AppendLine(node.Text);

            foreach (ParseNode n in node.Nodes)
                PrintNode(sb, n, indent + 2);
        }
        
        /// <summary>
        /// this is the entry point for executing and evaluating the parse tree.
        /// </summary>
        /// <param name="paramlist">additional optional input parameters</param>
        /// <returns>the output of the evaluation function</returns>
        public object Eval(params object[] paramlist)
        {
            return Nodes[0].Eval(this, paramlist);
        }
    }

    [Serializable]
    [XmlInclude(typeof(ParseTree))]
    public partial class ParseNode
    {
        protected string text;
        protected List<ParseNode> nodes;
        
        public List<ParseNode> Nodes { get {return nodes;} }
        
        [XmlIgnore] // avoid circular references when serializing
        public ParseNode Parent;
        public Token Token; // the token/rule

        [XmlIgnore] // skip redundant text (is part of Token)
        public string Text { // text to display in parse tree 
            get { return text;} 
            set { text = value; }
        } 

        public virtual ParseNode CreateNode(Token token, string text)
        {
            ParseNode node = new ParseNode(token, text);
            node.Parent = this;
            return node;
        }

        protected ParseNode(Token token, string text)
        {
            this.Token = token;
            this.text = text;
            this.nodes = new List<ParseNode>();
        }

        protected object GetValue(ParseTree tree, TokenType type, int index)
        {
            return GetValue(tree, type, ref index);
        }

        protected object GetValue(ParseTree tree, TokenType type, ref int index)
        {
            object o = null;
            if (index < 0) return o;

            // left to right
            foreach (ParseNode node in nodes)
            {
                if (node.Token.Type == type)
                {
                    index--;
                    if (index < 0)
                    {
                        o = node.Eval(tree);
                        break;
                    }
                }
            }
            return o;
        }

        /// <summary>
        /// this implements the evaluation functionality, cannot be used directly
        /// </summary>
        /// <param name="tree">the parsetree itself</param>
        /// <param name="paramlist">optional input parameters</param>
        /// <returns>a partial result of the evaluation</returns>
        internal object Eval(ParseTree tree, params object[] paramlist)
        {
            object Value = null;

            switch (Token.Type)
            {
                case TokenType.Start:
                    Value = EvalStart(tree, paramlist);
                    break;
                case TokenType.UseDirective:
                    Value = EvalUseDirective(tree, paramlist);
                    break;
                case TokenType.ClassDirective:
                    Value = EvalClassDirective(tree, paramlist);
                    break;
                case TokenType.BaseDirective:
                    Value = EvalBaseDirective(tree, paramlist);
                    break;
                case TokenType.OptionsDirective:
                    Value = EvalOptionsDirective(tree, paramlist);
                    break;
                case TokenType.Variable:
                    Value = EvalVariable(tree, paramlist);
                    break;
                case TokenType.FieldName:
                    Value = EvalFieldName(tree, paramlist);
                    break;
                case TokenType.Literal:
                    Value = EvalLiteral(tree, paramlist);
                    break;
                case TokenType.FunctionDefinition:
                    Value = EvalFunctionDefinition(tree, paramlist);
                    break;
                case TokenType.FunctionName:
                    Value = EvalFunctionName(tree, paramlist);
                    break;
                case TokenType.LocalVariables:
                    Value = EvalLocalVariables(tree, paramlist);
                    break;
                case TokenType.Body:
                    Value = EvalBody(tree, paramlist);
                    break;
                case TokenType.Call:
                    Value = EvalCall(tree, paramlist);
                    break;
                case TokenType.Function:
                    Value = EvalFunction(tree, paramlist);
                    break;
                case TokenType.FullFunctionName:
                    Value = EvalFullFunctionName(tree, paramlist);
                    break;
                case TokenType.StaticPrefix:
                    Value = EvalStaticPrefix(tree, paramlist);
                    break;
                case TokenType.InstancePrefix:
                    Value = EvalInstancePrefix(tree, paramlist);
                    break;
                case TokenType.ConstructorPrefix:
                    Value = EvalConstructorPrefix(tree, paramlist);
                    break;
                case TokenType.EvalConstruct:
                    Value = EvalEvalConstruct(tree, paramlist);
                    break;
                case TokenType.EvalBody:
                    Value = EvalEvalBody(tree, paramlist);
                    break;
                case TokenType.FormatString:
                    Value = EvalFormatString(tree, paramlist);
                    break;
                case TokenType.WhileCycle:
                    Value = EvalWhileCycle(tree, paramlist);
                    break;
                case TokenType.WhileCondition:
                    Value = EvalWhileCondition(tree, paramlist);
                    break;
                case TokenType.WhileBody:
                    Value = EvalWhileBody(tree, paramlist);
                    break;
                case TokenType.CycleSeparator:
                    Value = EvalCycleSeparator(tree, paramlist);
                    break;
                case TokenType.BoolCondition:
                    Value = EvalBoolCondition(tree, paramlist);
                    break;
                case TokenType.ForCycle:
                    Value = EvalForCycle(tree, paramlist);
                    break;
                case TokenType.ForCounter:
                    Value = EvalForCounter(tree, paramlist);
                    break;
                case TokenType.ForFrom:
                    Value = EvalForFrom(tree, paramlist);
                    break;
                case TokenType.ForTo:
                    Value = EvalForTo(tree, paramlist);
                    break;
                case TokenType.ForBody:
                    Value = EvalForBody(tree, paramlist);
                    break;
                case TokenType.IfCondition:
                    Value = EvalIfCondition(tree, paramlist);
                    break;
                case TokenType.IfTrueBranch:
                    Value = EvalIfTrueBranch(tree, paramlist);
                    break;
                case TokenType.IfFalseBranch:
                    Value = EvalIfFalseBranch(tree, paramlist);
                    break;
                case TokenType.Assignment:
                    Value = EvalAssignment(tree, paramlist);
                    break;
                case TokenType.AssignmentBody:
                    Value = EvalAssignmentBody(tree, paramlist);
                    break;
                case TokenType.MathOp:
                    Value = EvalMathOp(tree, paramlist);
                    break;
                case TokenType.HashAssignment:
                    Value = EvalHashAssignment(tree, paramlist);
                    break;
                case TokenType.Key:
                    Value = EvalKey(tree, paramlist);
                    break;
                case TokenType.VariablesDefinitions:
                    Value = EvalVariablesDefinitions(tree, paramlist);
                    break;
                case TokenType.ParamsDefinitions:
                    Value = EvalParamsDefinitions(tree, paramlist);
                    break;
                case TokenType.Params:
                    Value = EvalParams(tree, paramlist);
                    break;
                case TokenType.Param:
                    Value = EvalParam(tree, paramlist);
                    break;

                default:
                    Value = Token.Text;
                    break;
            }
            return Value;
        }

        protected virtual object EvalStart(ParseTree tree, params object[] paramlist)
        {
            return "Could not interpret input; no semantics implemented.";
        }

        protected virtual object EvalUseDirective(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalClassDirective(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalBaseDirective(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalOptionsDirective(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalVariable(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalFieldName(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalLiteral(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalFunctionDefinition(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalFunctionName(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalLocalVariables(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalBody(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalCall(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalFunction(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalFullFunctionName(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalStaticPrefix(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalInstancePrefix(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalConstructorPrefix(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalEvalConstruct(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalEvalBody(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalFormatString(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalWhileCycle(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalWhileCondition(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalWhileBody(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalCycleSeparator(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalBoolCondition(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalForCycle(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalForCounter(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalForFrom(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalForTo(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalForBody(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalIfCondition(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalIfTrueBranch(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalIfFalseBranch(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalAssignment(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalAssignmentBody(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalMathOp(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalHashAssignment(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalKey(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalVariablesDefinitions(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalParamsDefinitions(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalParams(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }

        protected virtual object EvalParam(ParseTree tree, params object[] paramlist)
        {
            throw new NotImplementedException();
        }


    }
    
    #endregion ParseTree
}
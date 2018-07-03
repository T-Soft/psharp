using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Core.Language.Model;

namespace Sharpen.Core.Parser {
	public static class Extensions {
		public static bool OfTokenType(this ParseNode node, TokenType tokenType)
		{
			return node.Token.Type == tokenType;
		}

		public static IEnumerable<ParseNode> GetChildrenOfTokenType(this ParseNode node, TokenType tokenType, bool recursive = false)
		{
			List<ParseNode> ret = new List<ParseNode>();
			ret.AddRange(node.Nodes.Where(n => n.OfTokenType(tokenType)).Select(n => n));
			
			return ret;
		}

		public static ParseNode GetChildOfTokenType(this ParseNode node, TokenType tokenType) {
			return GetChildrenOfTokenType(node,tokenType).FirstOrDefault();
		}

		public static string Text(this ParseNode node)
		{
			return node?.Token.Text;
		}

		public static string IdentifierString(this ParseNode node) {
			return node.GetChildOfTokenType(TokenType.IDENTIFIER)?.Text();
		}

		public static IEnumerable<string> IdentifierStringCollection(this ParseNode node) {
			return node.GetChildrenOfTokenType(TokenType.IDENTIFIER).ToStringCollection();
		}

		public static IEnumerable<string> ToStringCollection(this IEnumerable<ParseNode> nodes)
		{
			return nodes.Select(n => n.Token.Text);
		}

		public static string PreviousNodeIdentifierString(this IEnumerable<ParseNode> nodes, int nodeIndex)
		{
			var nodesA = nodes.ToArray();
			if (nodesA.Any())
			{
				if (nodeIndex < 0)
				{
					throw new IndexOutOfRangeException($"{nameof(nodeIndex)} must be a positive integer");
				}

				if(nodeIndex > nodesA.Count()) 
				{
					throw new IndexOutOfRangeException($"Nodes enumerable doesn't have element {nodeIndex}");
				}

				if (nodeIndex - 1 > 0)
				{
					return nodesA[nodeIndex - 1].IdentifierString();
				}
				else
				{
					throw new IndexOutOfRangeException($"Node {nodesA[nodeIndex].Text} doesn't have a previous node");
				}
			}
			else
			{
				throw new ArgumentException("Target node enumerable is empty");
			}
		}

		public static TokenType NextNodeTokenType(this IEnumerable<ParseNode> nodes, int nodeIndex) {
			ParseNode[] nodesA = nodes.ToArray();
			if(nodesA.Any()) {
				if(nodeIndex < 0) {
					throw new IndexOutOfRangeException($"{nameof(nodeIndex)} must be a positive integer");
				}

				if(nodeIndex > nodesA.Count()) {
					throw new IndexOutOfRangeException($"Nodes enumerable doesn't have element {nodeIndex}");
				}

				return nodeIndex + 1 <= nodesA.Length-1
					? nodesA[nodeIndex + 1].Token.Type
					: TokenType._UNDETERMINED_;
			} else {
				throw new ArgumentException("Target node enumerable is empty");
			}
		}
	}
}

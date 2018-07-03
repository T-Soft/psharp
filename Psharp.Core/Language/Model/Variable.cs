using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Parser;

namespace Sharpen.Core.Language.Model
{
	public sealed class Variable : LanguageEntity, ICodeGeneratingEntity
	{
		public DataType Type => _type;
		public Type CsType => MapType();

		private DataType _type;
		public string ClassName { get; } = null;
		public bool IsField => !string.IsNullOrEmpty(ClassName);

		public bool IsDeclared { get; private set; } = false;

		#region [CTORS]
		public Variable(ParseNode variableNode)
		{
			bool isStatic = variableNode.GetChildOfTokenType(TokenType.C) != null;
			bool isInstance = variableNode.GetChildOfTokenType(TokenType.DOT) != null;
			if (!isStatic && !isInstance)
			{
				Name = variableNode.IdentifierString();
			}
			else
			{
				ClassName = variableNode.IdentifierString();
				Name = variableNode.GetChildOfTokenType(TokenType.FieldName).IdentifierString();
			}
		}

		public Variable(string name)
		{
			Name = name;
			_type = DataType.Unknown;
		}

		public Variable(string name, string className) : this(name)
		{
			Name = name;
			ClassName = className;
		}

		public Variable(string name, string className, DataType type) : this(name)
		{
			Name = name;
			ClassName = className;
			_type = type;
		}

		public Variable(string name, DataType type) : this(name)
		{
			_type = type;
		}
		#endregion

		public void SetType(DataType type)
		{
			_type = type;
		}

		private Type MapType()
		{
			switch (Type)
			{
				case DataType.Bool:
					return typeof(bool);
				case DataType.Double:
					return typeof(double);
				case DataType.Int:
					return typeof(int);
				case DataType.String:
				case DataType.Plain:
					return typeof(string);
				case DataType.Unknown:
				default:
					return typeof(object);
			}
		}

		#region [ Equals && GetHashCode && (==) && (!=) ]

		public static bool operator ==(Variable var1, Variable var2)
		{
			return Variable.Equals(var1, var2);
		}

		public static bool operator !=(Variable var1, Variable var2)
		{
			return !Variable.Equals(var1, var2);
		}

		public static bool Equals(Variable a, Variable b)
		{
			if ((object) a == (object) b)
				return true;
			if (a == null || b == null)
				return false;
			return a.Equals(b);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			Variable variable = obj as Variable;
			if (variable == null)
			{
				return base.Equals(obj);
			}

			bool namesEqual = this.Name == variable.Name;
			bool typesEqual = this.Type == variable.Type;
			return namesEqual && typesEqual;
		}

		public override int GetHashCode()
		{
			// use only Name , Type
			return this.Name.GetHashCode() + this.Type.GetHashCode();
		}
		#endregion

		public string GenerateCode()
		{
			return IsField
				? $"{ClassName}.{Name}"
				: $"{Name}";
		}

		public string Declare()
		{
			IsDeclared = true;
			_type = DataType.Unknown;
			return $"{DataTypeParser.EmitTypeKeyword(_type)} {GenerateCode()};";
		}
	}
}

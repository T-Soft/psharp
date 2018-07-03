using System;
using System.Collections.Generic;

namespace Psharp.Core.Language.Model {
	public sealed class Method : LanguageEntity, ICodeGeneratingEntity {
		//public string Name { get; }
		public DataType ReturnType { set; get; }

		public readonly LanguageEntityTable<Variable> LocalVariables = new LanguageEntityTable<Variable>();
		public readonly LanguageEntityTable<Variable> InputParameters = new LanguageEntityTable<Variable>();

		public readonly List<string> Statements = new List<string>();

		public Method(string name)
		{
			Name = name;
			ReturnType = default(DataType);
		}

		public string GenerateCode() {
			throw new NotImplementedException();
		}

		#region [Equals, GetHashCode, (==), (!=)]
		public static bool operator ==(Method a, Method b) {
			return Method.Equals(a, b);
		}

		public static bool operator !=(Method a, Method b) {
			return !Method.Equals(a, b);
		}

		public static bool Equals(Method a, Method b) {
			if((object)a == (object)b)
				return true;
			if(a == null || b == null)
				return false;
			return a.Equals(b);
		}

		public override bool Equals(object obj) {
			if(obj == null)
				return false;

			Method variable = obj as Method;
			if(variable == null) {
				return base.Equals(obj);
			}

			bool namesEqual = this.Name == variable.Name;
			bool returnTypesEqual = this.ReturnType == variable.ReturnType;
			return namesEqual && returnTypesEqual;
		}

		public override int GetHashCode() {
			// use only Name , Type
			return this.Name.GetHashCode() + this.ReturnType.GetHashCode();
		}
		#endregion
	}
}

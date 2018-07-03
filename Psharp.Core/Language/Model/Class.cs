using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Language.Model {
	public class Class : LanguageEntity, ICodeGeneratingEntity
	{
		public LanguageEntityTable<Method> Methods { get; } = new LanguageEntityTable<Method>();
		//NOTE: think about whether fields will be Properties or just public Fields
		public LanguageEntityTable<Variable> Fields { get; } = new LanguageEntityTable<Variable>();

		public bool IsPartial { set; get; } = false;
		public string BaseClassName { set; get; } = null;

		public Class(string className)
		{
			Name = className;
		}

		public string GenerateCode() {
			// class is always sealed and public
			throw new NotImplementedException();
		}

		#region [Equals, GetHashCode, (==), (!=)]
		public static bool operator ==(Class a, Class b) {
			return Method.Equals(a, b);
		}

		public static bool operator !=(Class a, Class b) {
			return !Method.Equals(a, b);
		}

		public static bool Equals(Class a, Class b) {
			if((object)a == (object)b)
				return true;
			if(a == null || b == null)
				return false;
			return a.Equals(b);
		}

		public override bool Equals(object obj) {
			if(obj == null)
				return false;

			Class variable = obj as Class;
			if(variable == null) {
				return base.Equals(obj);
			}

			bool namesEqual = this.Name == variable.Name;
			return namesEqual;
		}

		public override int GetHashCode() {
			// use only Name
			return this.Name.GetHashCode();
		}
		#endregion
	}
}

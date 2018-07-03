using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Language.Model.Exceptions {
	public class MemberNotFoundException:Exception
	{
		public MemberNotFoundException(string memberName, string className) : base($"Member '{memberName}' not found in class '{className}'"){}
	}
}

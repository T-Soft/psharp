using System;

namespace Psharp.Core.Language.Model.Exceptions {
	public class MemberNotFoundException:Exception
	{
		public MemberNotFoundException(string memberName, string className) : base($"Member '{memberName}' not found in class '{className}'"){}
	}
}

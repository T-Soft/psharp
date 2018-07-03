using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Language.Model
{
	public class Namespace : LanguageEntity, ICodeGeneratingEntity
	{
		public LanguageEntityTable<Class> Classes { get; } = new LanguageEntityTable<Class>();

		public Namespace(string namespaceName)
		{
			Name = namespaceName;
		}

		public string GenerateCode()
		{
			throw new NotImplementedException();
		}
	}
}
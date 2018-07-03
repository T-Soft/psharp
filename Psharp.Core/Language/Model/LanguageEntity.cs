using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Language.Model
{
	public abstract class LanguageEntity : INamedEntity
	{
		public string Name { get; set; }
	}
}

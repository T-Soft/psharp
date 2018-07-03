using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Parser;
using Sharpen.Core.Validator;

namespace Sharpen.Core.Translator
{
	public interface ITranslator
	{
		void SetInputCode(string inputCode);
		TranslatorResult Translate(TranslateTarget target);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpen.Core.Generator;

namespace Sharpen.Core.Processors
{
	public class Postprocessor
	{
		private ICodeGeneratorResult _result;

		public Postprocessor(ICodeGeneratorResult generated)
		{
			_result = generated;
		}

		public ICodeGeneratorResult Run()
		{
			if (!_result.Success)
			{
				// if result has error postprocessing is not needed
				return _result;
			}

			return _result;
		}
	}
}

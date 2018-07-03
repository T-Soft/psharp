using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.ConsoleParameters
{
	public class InputParameterInfo
	{
		private string[] _args;
		[ArgBinding("-i")]
		public string InputFilePath { get; set; }
		[ArgBinding("-o")]
		public string OutputFilePath { get; set; } // NOTE: this parameter is optional

		public string SelfPath { get; }

		public Dictionary<TranslatorSwitch, bool> Switches { get; set; } = new Dictionary<TranslatorSwitch, bool>() {
			{TranslatorSwitch.Run, false},
			{TranslatorSwitch.CompileAssembly, false}
		};

		public Dictionary<string, PropertyInfo> KnownArguments = CommandLineBind.BuildBindings(typeof (InputParameterInfo));


		public bool Error { get; set; }
		public string ErrorMessage { get; set; }
		
		private bool CheckParameterCount()
		{
			// TODO: check parameter count
			return true;
		}

		private bool CheckParameters()
		{
			// TODO: check parameters
			return true;
		}

		private void ReadArguments() {
			for(int i = 0; i < _args.Length; i++)
			{
				if (_args[i].StartsWith("-"))
				{
					if (KnownArguments.ContainsKey(_args[i]))
					{
						KnownArguments[_args[i]].SetValue(this, _args[i + 1]);
					}
					else
					{
						TranslatorSwitch parsedSwitch = TranslatorSwitchParser.Parse(_args[i]);
						if (parsedSwitch != TranslatorSwitch.Unknown)
						{
							Switches[parsedSwitch] = true;
						}
					}
				}
			}
		}
		
		public InputParameterInfo(string[] args, string selfPath)
		{
			SelfPath = selfPath;
			_args = args;

			ReadArguments();

			if (string.IsNullOrEmpty(OutputFilePath))
			{
				OutputFilePath = Path.Combine(Path.GetFileName(InputFilePath).TrimEnd('p')+"cs");
			}
		}

		public InputParameterInfo()
		{

		}
	}
}

namespace Psharp.Core.ConsoleParameters
{
	public enum TranslatorSwitch
	{
		CompileAssembly = 0,
		Run,
		Unknown
	}

	public static class TranslatorSwitchParser
	{
		public static TranslatorSwitch Parse(string arg)
		{
			switch (arg) {
				case "-c":
					return TranslatorSwitch.CompileAssembly;
				case "-r":
					return TranslatorSwitch.Run;
				default:
					return TranslatorSwitch.Unknown;
			}
		}
	}
}

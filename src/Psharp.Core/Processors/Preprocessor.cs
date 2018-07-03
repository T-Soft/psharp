namespace Psharp.Core.Processors
{
	public class Preprocessor
	{
		private string _code;
		public Preprocessor(string codeToProcess)
		{
			_code = codeToProcess;
		}

		public string Run()
		{
			RearrangeDirectives();
			RemoveAtSignsFromDirectives();
			RemoveEmptySquareBrackets();
			HandleEscapedStrings();
			HandleMultilineStrings();
			AppendEof();
			FixLineEndings();
			return _code;
		}

		#region [Preprocessor methods]

		private void RearrangeDirectives()
		{
			//TODO: rearrange @USE, @CLASS, @OPTIONS, @BASE directives
		}

		/// <remarks>
		/// 0) @CLASS -> CLASS
		/// 1) @USE -> USE
		/// 2) @BASE -> BASE
		/// 3) @OPTIONS -> OPTIONS
		/// </remarks>
		private void RemoveAtSignsFromDirectives()
		{
			_code = _code.Replace("@USE", "USE").Replace("@CLASS", "CLASS").Replace("@BASE","BASE").Replace("@OPTIONS","OPTIONS");
		}

		private void RemoveEmptySquareBrackets()
		{
			_code = _code.Replace("][]", "]");
		}

		private void HandleEscapedStrings()
		{
			// TODO: handle escaped strings
		}

		private void HandleMultilineStrings()
		{
			// TODO: handle multiline strings
		}

		private void AppendEof()
		{
			_code = $"{_code}\r\n";
		}

		private void FixLineEndings()
		{
			_code = _code.Replace("\r\n", "\n"); // NOTE: this is because grammar NL(newline) is defined as '\n'
		}
		#endregion

	}
}

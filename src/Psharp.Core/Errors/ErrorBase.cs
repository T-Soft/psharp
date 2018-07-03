namespace Psharp.Core.Errors
{
	public abstract class ErrorBase
	{
		protected ErrorBase()
		{ }

		protected ErrorBase(string message, bool isWarning = false)
		{
			Message = message;
			IsWarning = isWarning;
		}

		public bool IsWarning { get; set; }
		public string Message { get; set; }

		public override string ToString() => Message;
	}
}

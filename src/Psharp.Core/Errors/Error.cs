using System;
using System.Text;

namespace Psharp.Core.Errors
{
	public enum ErrorType
	{
		Warning,
		Error,
		Aggregate
	}

	public class Error
	{
		public bool IsWarning { get; set; }
		public string Message { get; set; }
		public virtual ErrorType Type => IsWarning
			? ErrorType.Warning
			: ErrorType.Error;

		public Error() {}

		public Error(string message, bool isWarning = false)
		{
			Message = message;
			IsWarning = isWarning;
		}
		
		public Error(Exception ex)
		{
			IsWarning = false;
			string message = FlattenExceptionMessage(ex);
			Message = $"One or more exceptions happened.\n{message}";
		}

		private string FlattenExceptionMessage(Exception ex)
		{
			StringBuilder currentMessage = new StringBuilder();
			currentMessage.AppendLine(ex.Message);
			if(ex.InnerException != null)
			{
				currentMessage.AppendLine(FlattenExceptionMessage(ex.InnerException));
			}
			return currentMessage.ToString();
		}

		public override string ToString() => Message;
		
	}
}

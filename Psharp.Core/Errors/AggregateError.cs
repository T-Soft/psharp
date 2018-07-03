using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Errors
{
	public sealed class AggregateError : Error
	{
		private Error[] _errors;
		public int ErrorsCount=>_errors?.Length ?? 0;
		public override ErrorType Type => ErrorType.Aggregate;
		public AggregateError(params Error[] errors)
		{
			InnerErrors = errors;
		}

		public AggregateError(IEnumerable<Error> errors)
		{
			InnerErrors = errors.ToArray();
		}
		
		public Error[] InnerErrors
		{
			get { return _errors; }
			set {
				if (value == null) {
					throw new ArgumentNullException("Value","Inner errors can't be null");
				}
				_errors = value;
				if (ErrorsCount > 1)
				{
					Message = $"{ErrorsCount} errors occured. See inner errors for details";
				}
				else if (ErrorsCount == 1)
				{
					Message = _errors[0].Message;
				}

				IsWarning = value?.All(x => x.IsWarning) == true;
			}
		}

		public bool WarningsOnly()
		{
			return _errors.All(err => err.IsWarning);
		}

		public override string ToString()
		{
			if(ErrorsCount == 1)
			{
				return $"[{_errors.First().Type}] {Message}";
			}
			StringBuilder accumulatedErrorMessage = new StringBuilder();
			accumulatedErrorMessage.AppendLine($"{ErrorsCount} errors occured.");
			
			_errors.Aggregate(accumulatedErrorMessage, (acc, err) => acc.AppendLine($"[{err.Type}] {err.ToString()}"));
			return accumulatedErrorMessage.ToString();
		}
	}
}

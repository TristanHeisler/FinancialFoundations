using System;

namespace FinancialFoundations.StudentWork.Domain.Commands
{
	public class SubmitStudentAssignmentCommandError
	{
		public SubmitStudentAssignmentCommandError(Exception exception)
		{
			Exception = exception ?? throw new ArgumentNullException(nameof(exception));
		}

		public Exception Exception { get; }
	}
}
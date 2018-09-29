using System;
using System.Collections.Generic;
using System.Text;
using FinancialFoundations.Framework;

namespace FinancialFoundations.StudentWork.Domain.Commands
{
	public class SubmitStudentAssignmentCommand : ICommand<SubmitStudentAssignmentCommandError>
	{
		public SubmitStudentAssignmentCommand(StudentAssignmentSubmission data)
		{
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		public StudentAssignmentSubmission Data { get; }
	}
}

using System;
using FinancialFoundations.StudentWork.Domain;

namespace FinancialFoundations.StudentWork.CoreProcessing
{
	public class StudentGradeSubmissionBundle
	{
		public StudentGradeSubmissionBundle(AssignmentAnswerKey assignment, StudentAssignmentSubmission studentAssignmentSubmission)
		{
			AssignmentAnswerKey = assignment ?? throw new ArgumentNullException(nameof(assignment));
			StudentAssignmentSubmission = studentAssignmentSubmission ?? throw new ArgumentNullException(nameof(studentAssignmentSubmission));
		}

		public AssignmentAnswerKey AssignmentAnswerKey { get; }
		public StudentAssignmentSubmission StudentAssignmentSubmission { get; }
	}
}
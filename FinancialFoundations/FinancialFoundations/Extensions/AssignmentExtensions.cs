using System;
using FinancialFoundations.Models;
using FinancialFoundations.StudentWork.Domain;

namespace FinancialFoundations.Extensions
{
	public static class AssignmentExtensions
	{
		public static StudentAssignmentInProgress ToAssignmentInProgress(this Assignment source, Guid studentID)
		{
			return new StudentAssignmentInProgress(source.EducatorID, source.AssignmentID, studentID, source.MultipleChoiceQuestionCollection);
		}
	}
}
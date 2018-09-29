using System.Linq;
using FinancialFoundations.StudentWork.Domain;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public static class StudentAssignmentSubmissionDataSpecificationExtensions
	{
		public static StudentAssignmentSubmissionDataSpecification ToStudentAssignmentSubmissionDataSpecification(this StudentAssignmentSubmission source)
		{
			return new StudentAssignmentSubmissionDataSpecification
			{
				EducatorID = source.EducatorID,
				AssignmentID = source.AssignmentID,
				StudentID = source.StudentID,
				AnswerCollection = source.MultipleChoiceQuestionAnswerCollection.Select(x => x.ToStudentAssignmentSubmissionAnswerEntryDataSpecification()).ToArray()
			};
		}

		public static StudentAssignmentSubmission ToStudentAssignmentSubmission(this StudentAssignmentSubmissionDataSpecification source)
		{
			return new StudentAssignmentSubmission(source.EducatorID, source.AssignmentID, source.StudentID, source.AnswerCollection.Select(x => x.ToStudentAssignmentSubmissionMultipleChoiceQuestionAnswer()).ToArray());
		}
	}
}
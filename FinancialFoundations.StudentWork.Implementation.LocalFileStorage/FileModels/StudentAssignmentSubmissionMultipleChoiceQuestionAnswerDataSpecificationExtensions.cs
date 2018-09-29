using FinancialFoundations.StudentWork.Domain;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public static class StudentAssignmentSubmissionMultipleChoiceQuestionAnswerDataSpecificationExtensions
	{
		public static StudentAssignmentSubmissionMultipleChoiceQuestionAnswerDataSpecification ToStudentAssignmentSubmissionAnswerEntryDataSpecification(this StudentAssignmentSubmissionMultipleChoiceQuestionAnswer source)
		{
			return new StudentAssignmentSubmissionMultipleChoiceQuestionAnswerDataSpecification
			{
				QuestionID = source.QuestionID,
				AnswerID = source.AnswerID
			};
		}

		public static StudentAssignmentSubmissionMultipleChoiceQuestionAnswer ToStudentAssignmentSubmissionMultipleChoiceQuestionAnswer(this StudentAssignmentSubmissionMultipleChoiceQuestionAnswerDataSpecification source)
		{
			return new StudentAssignmentSubmissionMultipleChoiceQuestionAnswer(source.QuestionID, source.AnswerID);
		}
	}
}
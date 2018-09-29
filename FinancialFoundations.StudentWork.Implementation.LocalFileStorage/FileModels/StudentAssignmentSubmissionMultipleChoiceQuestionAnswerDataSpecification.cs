using System;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class StudentAssignmentSubmissionMultipleChoiceQuestionAnswerDataSpecification
	{
		public Guid QuestionID { get; set; }
		public Guid AnswerID { get; set; }
	}
}
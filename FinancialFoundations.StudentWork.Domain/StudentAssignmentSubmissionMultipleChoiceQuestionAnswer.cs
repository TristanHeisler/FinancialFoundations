using System;

namespace FinancialFoundations.StudentWork.Domain
{
	public class StudentAssignmentSubmissionMultipleChoiceQuestionAnswer
	{
		public StudentAssignmentSubmissionMultipleChoiceQuestionAnswer(Guid questionID, Guid answerID)
		{
			QuestionID = questionID;
			AnswerID = answerID;
		}

		public Guid QuestionID { get; }
		public Guid AnswerID { get; }
	}
}
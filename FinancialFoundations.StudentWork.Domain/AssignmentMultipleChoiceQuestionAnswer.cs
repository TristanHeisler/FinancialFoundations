using System;

namespace FinancialFoundations.StudentWork.Domain
{
	public class AssignmentMultipleChoiceQuestionAnswer
	{
		public AssignmentMultipleChoiceQuestionAnswer(Guid answerID, string answerText)
		{
			AnswerID = answerID;
			AnswerText = answerText ?? throw new ArgumentNullException(nameof(answerText));
		}

		public Guid AnswerID { get; }
		public string AnswerText { get; }
	}
}
using System;
using System.Collections.Generic;

namespace FinancialFoundations.StudentWork.Domain
{
	public class AssignmentMultipleChoiceQuestion
	{
		public AssignmentMultipleChoiceQuestion(Guid questionID, string questionText, IEnumerable<AssignmentMultipleChoiceQuestionAnswer> answerCollection)
		{
			QuestionID = questionID;
			QuestionText = questionText ?? throw new ArgumentNullException(nameof(questionText));
			AnswerCollection = answerCollection ?? throw new ArgumentNullException(nameof(answerCollection));
		}

		public Guid QuestionID { get; }
		public string QuestionText { get; }
		public IEnumerable<AssignmentMultipleChoiceQuestionAnswer> AnswerCollection { get; }
	}
}
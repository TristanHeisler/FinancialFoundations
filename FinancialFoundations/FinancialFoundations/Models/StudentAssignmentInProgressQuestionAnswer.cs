using System;
using Functional;

namespace FinancialFoundations.Models
{
	public class StudentAssignmentInProgressQuestionAnswer
	{
		public StudentAssignmentInProgressQuestionAnswer(Guid questionID, Option<Guid> chosenAnswerID)
		{
			QuestionID = questionID;
			ChosenAnswerID = chosenAnswerID;
		}

		public Guid QuestionID { get; }
		public Option<Guid> ChosenAnswerID { get; }
	}
}
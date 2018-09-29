using System;
using System.Collections.Generic;
using System.Linq;
using FinancialFoundations.StudentWork.Domain;
using Functional;

namespace FinancialFoundations.Models
{
	public class StudentAssignmentInProgress
	{
		private readonly Dictionary<Guid, Option<Guid>> _answerChosenLookup;

		public StudentAssignmentInProgress(Guid educatorID, Guid assignmentID, Guid studentID, IEnumerable<AssignmentMultipleChoiceQuestion> sourceMultipleChoiceQuestionCollection)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
			StudentID = studentID;
			_answerChosenLookup = sourceMultipleChoiceQuestionCollection.ToDictionary(x => x.QuestionID, x => Option.None<Guid>());
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
		public Guid StudentID { get; }
		public IEnumerable<StudentAssignmentInProgressQuestionAnswer> AssignmentAnswers => _answerChosenLookup.Select(x => new StudentAssignmentInProgressQuestionAnswer(x.Key, x.Value));

		public void SetAnswer(Guid questionID, Guid answerID)
		{
			_answerChosenLookup[questionID] = Option.Some(answerID);
		}
	}
}
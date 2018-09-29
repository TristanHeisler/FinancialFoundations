using System;
using System.Linq;
using FinancialFoundations.StudentWork.Domain;
using Functional;

namespace FinancialFoundations.Models
{
	public static class StudentAssignmentInProgressExtensions
	{
		public static Option<StudentAssignmentSubmission> ToStudentAssignmentSubmission(this StudentAssignmentInProgress source)
		{
			return Result.Try(() =>
			{
				var chosenAnswers = source.AssignmentAnswers.Select(x => new StudentAssignmentSubmissionMultipleChoiceQuestionAnswer(x.QuestionID, x.ChosenAnswerID.Match(s => s, () => throw new Exception())));
				return new StudentAssignmentSubmission(source.EducatorID, source.AssignmentID, source.StudentID, chosenAnswers);
			}).ToOption();
		}
	}
}
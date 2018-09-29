using System.Linq;

namespace FinancialFoundations.StudentWork.CoreProcessing
{
	public static class StudentGradeSubmissionBundleExtensions
	{
		public static StudentGrade ComputeGrade(this StudentGradeSubmissionBundle source)
		{
			var assignmentAnswerKeyMultipleChoiceQuestionAnswerLookup = source.AssignmentAnswerKey.MultipleChoiceQuestionAnswerCollection.ToDictionary(x => x.QuestionID, x => x.AnswerID);
			return new StudentGrade(source.StudentAssignmentSubmission.MultipleChoiceQuestionAnswerCollection.Count(x => x.AnswerID == assignmentAnswerKeyMultipleChoiceQuestionAnswerLookup[x.QuestionID]), source.AssignmentAnswerKey.MultipleChoiceQuestionAnswerCollection.Count());
		}
	}
}

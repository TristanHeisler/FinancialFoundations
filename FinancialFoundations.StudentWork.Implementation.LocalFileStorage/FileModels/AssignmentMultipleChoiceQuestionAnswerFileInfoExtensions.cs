using System.IO;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public static class AssignmentMultipleChoiceQuestionAnswerFileInfoExtensions
	{
		public static string ToFilePath(this AssignmentMultipleChoiceQuestionAnswerFileInfo source)
			=> Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, $"assignmentMultipleChoiceQuestion-({source.EducatorID},{source.AssignmentID},{source.QuestionID},{source.AnswerID}).json");
	}
}
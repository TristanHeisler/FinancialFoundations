using System.IO;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public static class AssignmentMultipleChoiceQuestionFileInfoExtensions
	{
		public static string ToFilePath(this AssignmentMultipleChoiceQuestionFileInfo source)
			=> Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, $"assignmentMultipleChoiceQuestion-({source.EducatorID},{source.AssignmentID},{source.QuestionID}).json");
	}
}
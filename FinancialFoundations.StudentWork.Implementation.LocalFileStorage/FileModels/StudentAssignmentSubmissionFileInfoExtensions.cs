using System.IO;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public static class StudentAssignmentSubmissionFileInfoExtensions
	{
		public static string ToFilePath(this StudentAssignmentSubmissionFileInfo source)
			=> Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, $"studentAssignmentSubmission-({source.EducatorID},{source.AssignmentID},{source.StudentID}).json");
	}
}
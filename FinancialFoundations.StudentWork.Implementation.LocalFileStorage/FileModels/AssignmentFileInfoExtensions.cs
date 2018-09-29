using System.IO;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public static class AssignmentFileInfoExtensions
	{
		public static string ToFilePath(this AssignmentFileInfo source) => Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, $"unit-({source.EducatorID},{source.AssignmentID}).json");
	}
}
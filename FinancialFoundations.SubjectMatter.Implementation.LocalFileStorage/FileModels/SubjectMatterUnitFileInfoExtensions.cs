using System.IO;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitFileInfoExtensions
	{
		public static string ToFilePath(this SubjectMatterUnitFileInfo source) => Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, $"unit-({source.EducatorID},{source.SubjectMatterUnitID}).json");
	}
}
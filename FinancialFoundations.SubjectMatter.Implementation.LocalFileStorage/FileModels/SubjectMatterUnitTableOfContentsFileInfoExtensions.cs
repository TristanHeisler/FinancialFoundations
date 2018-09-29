using System.IO;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitTableOfContentsFileInfoExtensions
	{
		public static string ToFilePath(this SubjectMatterUnitTableOfContentsFileInfo source) => Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, $"tableOfContents-{source.EducatorID}.json");
	}
}
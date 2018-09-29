using System.Linq;
using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitTableOfContentsSpecificationExtensions
	{
		public static SubjectMatterUnitTableOfContentsSpecification ToSubjectMatterUnitTableOfContentsSpecification(this SubjectMatterUnitTableOfContents source)
		{
			return new SubjectMatterUnitTableOfContentsSpecification
			{
				EducatorID = source.EducatorID,
				EntryCollection = source.EntryCollection.Select(x => x.ToSubjectMatterUnitTableOfContentsEntrySpecification()).ToArray()
			};
		}

		public static SubjectMatterUnitTableOfContents ToSubjectMatterUnitTableOfContents(this SubjectMatterUnitTableOfContentsSpecification source)
		{
			return new SubjectMatterUnitTableOfContents(source.EducatorID, source.EntryCollection.Select(x => x.ToSubjectMatterUnitTableOfContentsEntry()).ToArray());
		}
	}
}
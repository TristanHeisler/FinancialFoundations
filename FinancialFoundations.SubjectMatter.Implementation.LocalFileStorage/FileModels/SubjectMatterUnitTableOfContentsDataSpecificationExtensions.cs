using System.Linq;
using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitTableOfContentsDataSpecificationExtensions
	{
		public static SubjectMatterUnitTableOfContentsDataSpecification ToSubjectMatterUnitTableOfContentsSpecification(this SubjectMatterUnitTableOfContents source)
		{
			return new SubjectMatterUnitTableOfContentsDataSpecification
			{
				EducatorID = source.EducatorID,
				EntryCollection = source.EntryCollection.Select(x => x.ToSubjectMatterUnitTableOfContentsEntrySpecification()).ToArray()
			};
		}

		public static SubjectMatterUnitTableOfContents ToSubjectMatterUnitTableOfContents(this SubjectMatterUnitTableOfContentsDataSpecification source)
		{
			return new SubjectMatterUnitTableOfContents(source.EducatorID, source.EntryCollection.Select(x => x.ToSubjectMatterUnitTableOfContentsEntry()).ToArray());
		}
	}
}
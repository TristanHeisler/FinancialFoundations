using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitTableOfContentsEntrySpecificationExtensions
	{
		public static SubjectMatterUnitTableOfContentsEntrySpecification ToSubjectMatterUnitTableOfContentsEntrySpecification(this SubjectMatterUnitTableOfContentsEntry source)
		{
			return new SubjectMatterUnitTableOfContentsEntrySpecification
			{
				SubjectMatterUnitID = source.SubjectMatterUnitID,
				Title = source.Title,
				Completed = source.Completed
			};
		}

		public static SubjectMatterUnitTableOfContentsEntry ToSubjectMatterUnitTableOfContentsEntry(this SubjectMatterUnitTableOfContentsEntrySpecification source)
		{
			return new SubjectMatterUnitTableOfContentsEntry(source.SubjectMatterUnitID, source.Title, source.Completed);
		}
	}
}
using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitTableOfContentsEntryDataSpecificationExtensions
	{
		public static SubjectMatterUnitTableOfContentsEntryDataSpecification ToSubjectMatterUnitTableOfContentsEntrySpecification(this SubjectMatterUnitTableOfContentsEntry source)
		{
			return new SubjectMatterUnitTableOfContentsEntryDataSpecification
			{
				SubjectMatterUnitID = source.SubjectMatterUnitID,
				Title = source.Title,
				Completed = source.Completed
			};
		}

		public static SubjectMatterUnitTableOfContentsEntry ToSubjectMatterUnitTableOfContentsEntry(this SubjectMatterUnitTableOfContentsEntryDataSpecification source)
		{
			return new SubjectMatterUnitTableOfContentsEntry(source.SubjectMatterUnitID, source.Title, source.Completed);
		}
	}
}
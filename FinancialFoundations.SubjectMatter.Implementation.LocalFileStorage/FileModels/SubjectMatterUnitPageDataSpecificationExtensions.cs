using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitPageDataSpecificationExtensions
	{
		public static SubjectMatterUnitPageDataSpecification ToSubjectMatterUnitPageSpecification(this SubjectMatterUnitPage source)
		{
			return new SubjectMatterUnitPageDataSpecification
			{
				EducatorID = source.EducatorID,
				SubjectMatterUnitID = source.SubjectMatterUnitID,
				Title = source.Title,
				Content = source.Content
			};
		}

		public static SubjectMatterUnitPage ToSubjectMatterUnitPage(this SubjectMatterUnitPageDataSpecification source)
		{
			return new SubjectMatterUnitPage(source.EducatorID, source.SubjectMatterUnitID, source.Title, source.Content);
		}
	}
}
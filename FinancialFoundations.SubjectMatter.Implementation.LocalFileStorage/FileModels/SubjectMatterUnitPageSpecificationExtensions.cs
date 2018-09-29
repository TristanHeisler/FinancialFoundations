using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitPageSpecificationExtensions
	{
		public static SubjectMatterUnitPageSpecification ToSubjectMatterUnitPageSpecification(this SubjectMatterUnitPage source)
		{
			return new SubjectMatterUnitPageSpecification
			{
				EducatorID = source.EducatorID,
				SubjectMatterUnitID = source.SubjectMatterUnitID
			};
		}

		public static SubjectMatterUnitPage ToSubjectMatterUnitPage(this SubjectMatterUnitPageSpecification source)
		{
			return new SubjectMatterUnitPage(source.EducatorID, source.SubjectMatterUnitID);
		}
	}
}
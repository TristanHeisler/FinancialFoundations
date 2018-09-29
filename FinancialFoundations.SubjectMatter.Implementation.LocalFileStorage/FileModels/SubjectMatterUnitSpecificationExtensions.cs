using System.Linq;
using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitSpecificationExtensions
	{
		public static SubjectMatterUnitSpecification ToSubjectMatterUnitSpecification(this SubjectMatterUnit source)
		{
			return new SubjectMatterUnitSpecification
			{
				EducatorID = source.EducatorID,
				SubjectMatterUnitID = source.SubjectMatterUnitID,
				PageCollection = source.PageCollection.Select(x => x.ToSubjectMatterUnitPageSpecification()).ToArray(),
				AssociatedAssignmentID = source.AssociatedAssignmentID
			};
		}

		public static SubjectMatterUnit ToSubjectMatterUnit(this SubjectMatterUnitSpecification source)
		{
			return new SubjectMatterUnit(source.EducatorID, source.SubjectMatterUnitID, source.PageCollection.Select(x => x.ToSubjectMatterUnitPage()), source.AssociatedAssignmentID);
		}
	}
}
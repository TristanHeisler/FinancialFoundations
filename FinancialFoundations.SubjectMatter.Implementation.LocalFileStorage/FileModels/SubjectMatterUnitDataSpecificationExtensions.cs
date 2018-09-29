using System.Linq;
using FinancialFoundations.SubjectMatter.Domain;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public static class SubjectMatterUnitDataSpecificationExtensions
	{
		public static SubjectMatterUnitDataSpecification ToSubjectMatterUnitSpecification(this SubjectMatterUnit source)
		{
			return new SubjectMatterUnitDataSpecification
			{
				EducatorID = source.EducatorID,
				SubjectMatterUnitID = source.SubjectMatterUnitID,
				PageCollection = source.PageCollection.Select(x => x.ToSubjectMatterUnitPageSpecification()).ToArray(),
				AssociatedAssignmentID = source.AssociatedAssignmentID
			};
		}

		public static SubjectMatterUnit ToSubjectMatterUnit(this SubjectMatterUnitDataSpecification source)
		{
			return new SubjectMatterUnit(source.EducatorID, source.SubjectMatterUnitID, source.PageCollection.Select(x => x.ToSubjectMatterUnitPage()), source.AssociatedAssignmentID);
		}
	}
}
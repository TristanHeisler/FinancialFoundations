using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class SubjectMatterUnitSpecification
	{
		public Guid EducatorID { get; set; }
		public Guid SubjectMatterUnitID { get; set; }
		public SubjectMatterUnitPageSpecification[] PageCollection { get; set; }
		public Guid AssociatedAssignmentID { get; set; }
	}
}

using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class SubjectMatterUnitDataSpecification
	{
		public Guid EducatorID { get; set; }
		public Guid SubjectMatterUnitID { get; set; }
		public SubjectMatterUnitPageDataSpecification[] PageCollection { get; set; }
		public Guid AssociatedAssignmentID { get; set; }
	}
}

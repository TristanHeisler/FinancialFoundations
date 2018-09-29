using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class SubjectMatterUnitPageSpecification
	{
		public Guid EducatorID { get; set; }
		public Guid SubjectMatterUnitID { get; set; }
	}
}
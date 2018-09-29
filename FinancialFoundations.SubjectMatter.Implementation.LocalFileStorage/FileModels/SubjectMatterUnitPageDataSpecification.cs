using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class SubjectMatterUnitPageDataSpecification
	{
		public Guid EducatorID { get; set; }
		public Guid SubjectMatterUnitID { get; set; }
		public string Content { get; set; }
	}
}
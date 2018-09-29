using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class SubjectMatterUnitTableOfContentsSpecification
	{
		public Guid EducatorID { get; set; }
		public SubjectMatterUnitTableOfContentsEntrySpecification[] EntryCollection { get; set; }
	}
}

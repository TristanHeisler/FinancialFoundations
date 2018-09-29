using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class SubjectMatterUnitTableOfContentsDataSpecification
	{
		public Guid EducatorID { get; set; }
		public SubjectMatterUnitTableOfContentsEntryDataSpecification[] EntryCollection { get; set; }
	}
}

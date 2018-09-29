using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class SubjectMatterUnitTableOfContentsEntrySpecification
	{
		public Guid SubjectMatterUnitID { get; set; }
		public string Title { get; set; }
		public bool Completed { get; set; }
	}
}
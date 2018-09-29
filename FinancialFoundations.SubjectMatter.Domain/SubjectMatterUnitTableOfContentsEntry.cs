using System;

namespace FinancialFoundations.SubjectMatter.Domain
{
	public class SubjectMatterUnitTableOfContentsEntry
	{
		public SubjectMatterUnitTableOfContentsEntry(Guid subjectMatterUnitID, string title)
		{
			SubjectMatterUnitID = subjectMatterUnitID;
			Title = title;
		}

		public Guid SubjectMatterUnitID { get; }
		public string Title { get; }
	}
}
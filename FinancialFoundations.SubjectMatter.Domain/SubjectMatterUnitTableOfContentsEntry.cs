using System;

namespace FinancialFoundations.SubjectMatter.Domain
{
	public class SubjectMatterUnitTableOfContentsEntry
	{
		public SubjectMatterUnitTableOfContentsEntry(Guid subjectMatterUnitID, string title, bool completed)
		{
			SubjectMatterUnitID = subjectMatterUnitID;
			Title = title;
			Completed = completed;
		}

		public Guid SubjectMatterUnitID { get; }
		public string Title { get; }
		public bool Completed { get; }
	}
}
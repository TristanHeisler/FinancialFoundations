using System;
using System.Collections.Generic;

namespace FinancialFoundations.SubjectMatter.Domain
{
	public class SubjectMatterUnitTableOfContents
	{
		public SubjectMatterUnitTableOfContents(Guid educatorID, IEnumerable<SubjectMatterUnitTableOfContentsEntry> entryCollection)
		{
			EducatorID = educatorID;
			EntryCollection = entryCollection ?? throw new ArgumentNullException(nameof(entryCollection));
		}

		public Guid EducatorID { get; }
		public IEnumerable<SubjectMatterUnitTableOfContentsEntry> EntryCollection { get; }
	}
}
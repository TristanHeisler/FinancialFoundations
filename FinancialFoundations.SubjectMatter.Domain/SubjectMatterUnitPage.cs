using System;

namespace FinancialFoundations.SubjectMatter.Domain
{
	public class SubjectMatterUnitPage
	{
		public SubjectMatterUnitPage(Guid subjectMatterUnitID)
		{
			SubjectMatterUnitID = subjectMatterUnitID;
		}

		public Guid SubjectMatterUnitID { get; }
	}
}
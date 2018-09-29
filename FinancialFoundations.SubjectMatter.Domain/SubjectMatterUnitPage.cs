using System;

namespace FinancialFoundations.SubjectMatter.Domain
{
	public class SubjectMatterUnitPage
	{
		public SubjectMatterUnitPage(Guid educatorID, Guid subjectMatterUnitID)
		{
			EducatorID = educatorID;
			SubjectMatterUnitID = subjectMatterUnitID;
		}

		public Guid EducatorID { get; }
		public Guid SubjectMatterUnitID { get; }
	}
}
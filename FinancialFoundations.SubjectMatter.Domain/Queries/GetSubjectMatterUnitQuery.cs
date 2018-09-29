using System;
using FinancialFoundations.Framework;

namespace FinancialFoundations.SubjectMatter.Domain.Queries
{
	public class GetSubjectMatterUnitQuery : IQuery<SubjectMatterUnit>
	{
		public GetSubjectMatterUnitQuery(Guid educatorID, Guid subjectMatterID)
		{
			EducatorID = educatorID;
			SubjectMatterID = subjectMatterID;
		}

		public Guid EducatorID { get; }
		public Guid SubjectMatterID { get; }
	}
}

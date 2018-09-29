using System;
using FinancialFoundations.Framework;
using Functional;

namespace FinancialFoundations.SubjectMatter.Domain.Queries
{
	public class GetSubjectMatterUnitQuery : IQuery<Result<SubjectMatterUnit, Exception>>
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

using System;
using FinancialFoundations.Framework;
using Functional;

namespace FinancialFoundations.SubjectMatter.Domain.Queries
{
	public class GetSubjectMatterUnitTableOfContentsQuery : IQuery<Result<SubjectMatterUnitTableOfContents, Exception>>
	{
		public GetSubjectMatterUnitTableOfContentsQuery(Guid educatorID)
		{
			EducatorID = educatorID;
		}

		public Guid EducatorID { get; }
	}
}
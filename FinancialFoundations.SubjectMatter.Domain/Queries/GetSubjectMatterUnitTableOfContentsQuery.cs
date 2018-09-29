using System;
using FinancialFoundations.Framework;

namespace FinancialFoundations.SubjectMatter.Domain.Queries
{
	public class GetSubjectMatterUnitTableOfContentsQuery : IQuery<SubjectMatterUnitTableOfContents>
	{
		public GetSubjectMatterUnitTableOfContentsQuery(Guid educatorID)
		{
			EducatorID = educatorID;
		}

		public Guid EducatorID { get; }
	}
}
using System;
using System.Collections.Generic;
using FinancialFoundations.Framework;

namespace FinancialFoundations.SubjectMatter.Domain.Queries
{
	public class GetSubjectMatterUnitTableOfContentsQuery : IQuery<IEnumerable<SubjectMatterUnitTableOfContentsEntry>>
	{
		public GetSubjectMatterUnitTableOfContentsQuery(Guid educatorID)
		{
			EducatorID = educatorID;
		}

		public Guid EducatorID { get; }
	}
}
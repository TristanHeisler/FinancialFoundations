using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;
using FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.Constants;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetSubjectMatterUnitTableOfContentsQueryHandler : IAsyncQueryHandler<GetSubjectMatterUnitTableOfContentsQuery, IEnumerable<SubjectMatterUnitTableOfContentsEntry>>
	{
		public async Task<IEnumerable<SubjectMatterUnitTableOfContentsEntry>> Handle(GetSubjectMatterUnitTableOfContentsQuery parameters)
		{
			// fake retrieving from the web...
			await Task.Delay(1000);

			return new[]
			{
				new SubjectMatterUnitTableOfContentsEntry(UnitConstants.Unit1, "Unit 1: Introduction"),
				new SubjectMatterUnitTableOfContentsEntry(UnitConstants.Unit2, "Unit 2: Stuff 1"),
				new SubjectMatterUnitTableOfContentsEntry(UnitConstants.Unit3, "Unit 3: Stuff 2")
			};
		}
	}
}

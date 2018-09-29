using System;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetSubjectMatterUnitQueryHandler : IAsyncQueryHandler<GetSubjectMatterUnitQuery, SubjectMatterUnit>
	{
		public async Task<SubjectMatterUnit> Handle(GetSubjectMatterUnitQuery parameters)
		{
			await Task.Delay(1000);

			throw new NotImplementedException();
		}
	}
}
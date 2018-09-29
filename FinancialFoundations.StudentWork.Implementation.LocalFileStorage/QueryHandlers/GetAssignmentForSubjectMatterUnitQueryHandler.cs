using System;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Queries;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetAssignmentForSubjectMatterUnitQueryHandler : IAsyncQueryHandler<GetAssignmentQuery, Assignment>
	{
		public async Task<Assignment> Handle(GetAssignmentQuery parameters)
		{
			// fake retrieving from the web...
			await Task.Delay(1000);

			// TODO: instantiate Assignment
			throw new NotImplementedException();
		}
	}
}

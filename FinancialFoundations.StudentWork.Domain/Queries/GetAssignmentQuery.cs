using System;
using FinancialFoundations.Framework;

namespace FinancialFoundations.StudentWork.Domain.Queries
{
	public class GetAssignmentQuery : IQuery<Assignment>
	{
		public GetAssignmentQuery(Guid educatorID, Guid assignmentID)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
	}
}

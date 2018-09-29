using System;
using System.Collections.Generic;
using System.Text;
using FinancialFoundations.Framework;
using Functional;

namespace FinancialFoundations.StudentWork.Domain.Queries
{
	public class GetAssignmentAnswerKeyQuery : IQuery<Result<AssignmentAnswerKey, Exception>>
	{
		public GetAssignmentAnswerKeyQuery(Guid educatorID, Guid assignmentID)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
	}
}

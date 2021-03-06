﻿using System;
using FinancialFoundations.Framework;
using Functional;

namespace FinancialFoundations.StudentWork.Domain.Queries
{
	public class GetAssignmentQuery : IQuery<Result<Assignment, Exception>>
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

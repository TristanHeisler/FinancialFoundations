using System;
using System.Collections.Generic;
using System.Text;
using FinancialFoundations.Framework;
using Functional;

namespace FinancialFoundations.StudentWork.Domain.Queries
{
	public class GetStudentSubmissionForAssignmentQuery : IQuery<Result<StudentAssignmentSubmission, Exception>>
	{
		public GetStudentSubmissionForAssignmentQuery(Guid educatorID, Guid assignmentID, Guid studentID)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
			StudentID = studentID;
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
		public Guid StudentID { get; }
	}
}

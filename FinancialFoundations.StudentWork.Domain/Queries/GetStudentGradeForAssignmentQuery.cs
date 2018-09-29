using System;
using System.Collections.Generic;
using System.Text;
using FinancialFoundations.Framework;
using Functional;

namespace FinancialFoundations.StudentWork.Domain.Queries
{
	public class GetStudentGradeForAssignmentQuery : IQuery<Result<StudentGrade, Exception>>
	{
		public GetStudentGradeForAssignmentQuery(Guid educatorID, Guid assignmentID, Guid studentID)
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

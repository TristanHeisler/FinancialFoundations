using System;

namespace FinancialFoundations.StudentWork.Domain
{
	public class Assignment
	{
		public Assignment(Guid assignmentID)
		{
			AssignmentID = assignmentID;
		}

		public Guid AssignmentID { get; }
	}
}
using System;
using FinancialFoundations.StudentWork.Domain;

namespace FinancialFoundations
{
	public class AssignmentPageViewModelConfiguration
	{
		public AssignmentPageViewModelConfiguration(Guid studentID, Assignment assignment)
		{
			StudentID = studentID;
			Assignment = assignment;
		}

		public Guid StudentID { get; }
		public Assignment Assignment { get; }
	}
}
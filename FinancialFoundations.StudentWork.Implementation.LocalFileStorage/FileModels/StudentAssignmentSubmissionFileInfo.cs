using System;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public class StudentAssignmentSubmissionFileInfo
	{
		public StudentAssignmentSubmissionFileInfo(Guid educatorID, Guid assignmentID, Guid studentID)
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
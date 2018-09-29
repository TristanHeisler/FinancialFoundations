using System;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public class AssignmentFileInfo
	{
		public AssignmentFileInfo(Guid educatorID, Guid assignmentID)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
	}
}

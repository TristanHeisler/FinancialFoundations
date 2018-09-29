using System;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public class AssignmentMultipleChoiceQuestionFileInfo
	{
		public AssignmentMultipleChoiceQuestionFileInfo(Guid educatorID, Guid assignmentID, Guid questionID)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
			QuestionID = questionID;
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
		public Guid QuestionID { get; }
	}
}
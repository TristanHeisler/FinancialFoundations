using System;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	public class AssignmentMultipleChoiceQuestionAnswerFileInfo
	{
		public AssignmentMultipleChoiceQuestionAnswerFileInfo(Guid educatorID, Guid assignmentID, Guid questionID, Guid answerID)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
			QuestionID = questionID;
			AnswerID = answerID;
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
		public Guid QuestionID { get; }
		public Guid AnswerID { get; }
	}
}
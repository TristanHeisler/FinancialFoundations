using System;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class AssignmentMultipleChoiceQuestionDataSpecification
	{
		public Guid EducatorID { get; set; }
		public Guid AssignmentID { get; set; }
		public Guid QuestionID { get; set; }
		public string QuestionText { get; set; }
		public Guid[] AnswerIDCollection { get; set; }
		public Guid CorrectAnswerID { get; set; }
	}
}
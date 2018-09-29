using System;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class AssignmentMultipleChoiceQuestionAnswerDataSpecification
	{
		public Guid EducatorID { get; set; }
		public Guid AssignmentID { get; set; }
		public Guid QuestionID { get; set; }
		public Guid AnswerID { get; set; }
		public string AnswerText { get; set; }
	}
}
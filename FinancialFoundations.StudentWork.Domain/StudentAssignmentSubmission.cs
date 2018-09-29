using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialFoundations.StudentWork.Domain
{
	public class StudentAssignmentSubmission
	{
		public StudentAssignmentSubmission(Guid educatorID, Guid assignmentID, Guid studentID, IEnumerable<StudentAssignmentSubmissionMultipleChoiceQuestionAnswer> multipleChoiceQuestionAnswerCollection)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
			StudentID = studentID;
			MultipleChoiceQuestionAnswerCollection = multipleChoiceQuestionAnswerCollection ?? throw new ArgumentNullException(nameof(multipleChoiceQuestionAnswerCollection));
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
		public Guid StudentID { get; }
		public IEnumerable<StudentAssignmentSubmissionMultipleChoiceQuestionAnswer> MultipleChoiceQuestionAnswerCollection { get; }
	}

	public class AssignmentAnswerKey
	{
		public AssignmentAnswerKey(Guid educatorID, Guid assignmentID, IEnumerable<AssignmentAnswerKeyMultipleChoiceQuestionAnswer> multipleChoiceQuestionAnswerCollection)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
			MultipleChoiceQuestionAnswerCollection = multipleChoiceQuestionAnswerCollection ?? throw new ArgumentNullException(nameof(multipleChoiceQuestionAnswerCollection));
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
		public IEnumerable<AssignmentAnswerKeyMultipleChoiceQuestionAnswer> MultipleChoiceQuestionAnswerCollection { get; }
	}

	public class AssignmentAnswerKeyMultipleChoiceQuestionAnswer
	{
		public AssignmentAnswerKeyMultipleChoiceQuestionAnswer(Guid questionID, Guid answerID)
		{
			QuestionID = questionID;
			AnswerID = answerID;
		}

		public Guid QuestionID { get; }
		public Guid AnswerID { get; }
	}
}

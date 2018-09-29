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
}

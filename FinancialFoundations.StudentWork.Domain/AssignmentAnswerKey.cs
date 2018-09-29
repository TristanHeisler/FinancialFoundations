using System;
using System.Collections.Generic;

namespace FinancialFoundations.StudentWork.Domain
{
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
}
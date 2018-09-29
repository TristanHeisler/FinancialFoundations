using System;
using System.Collections.Generic;

namespace FinancialFoundations.StudentWork.Domain
{
	public class Assignment
	{
		public Assignment(Guid educatorID, Guid assignmentID, IEnumerable<AssignmentMultipleChoiceQuestion> multipleChoiceQuestionCollection)
		{
			EducatorID = educatorID;
			AssignmentID = assignmentID;
			MultipleChoiceQuestionCollection = multipleChoiceQuestionCollection ?? throw new ArgumentNullException(nameof(multipleChoiceQuestionCollection));
		}

		public Guid EducatorID { get; }
		public Guid AssignmentID { get; }
		public IEnumerable<AssignmentMultipleChoiceQuestion> MultipleChoiceQuestionCollection { get; }
	}
}
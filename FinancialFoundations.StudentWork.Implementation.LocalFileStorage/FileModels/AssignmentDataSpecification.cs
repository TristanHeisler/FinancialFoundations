using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels
{
	[Serializable]
	public class AssignmentDataSpecification
	{
		public Guid EducatorID { get; set; }
		public Guid AssignmentID { get; set; }
		public Guid[] MultipleChoiceQuestionIDCollection { get; set; }
	}
}

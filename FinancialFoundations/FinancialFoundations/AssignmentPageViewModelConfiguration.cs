using FinancialFoundations.StudentWork.Domain;

namespace FinancialFoundations
{
	public class AssignmentPageViewModelConfiguration
	{
		public AssignmentPageViewModelConfiguration(Assignment assignment)
		{
			Assignment = assignment;
		}

		public Assignment Assignment { get; }
	}
}
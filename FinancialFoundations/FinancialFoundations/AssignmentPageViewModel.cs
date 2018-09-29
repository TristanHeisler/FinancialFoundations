using System;
using System.ComponentModel;
using System.Text;
using FinancialFoundations.Extensions;
using FinancialFoundations.Models;

namespace FinancialFoundations
{
    class AssignmentPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

	    private readonly AssignmentPageViewModelConfiguration _configuration;
	    private readonly StudentAssignmentInProgress _assignmentData;

	    public AssignmentPageViewModel(AssignmentPageViewModelConfiguration configuration)
	    {
		    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		    _assignmentData = configuration.Assignment.ToAssignmentInProgress(configuration.StudentID);
	    }
    }
}

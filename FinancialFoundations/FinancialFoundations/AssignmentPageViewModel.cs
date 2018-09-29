using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FinancialFoundations
{
    class AssignmentPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

	    private readonly AssignmentPageViewModelConfiguration _configuration;

	    public AssignmentPageViewModel(AssignmentPageViewModelConfiguration configuration)
	    {
		    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
	    }
    }
}

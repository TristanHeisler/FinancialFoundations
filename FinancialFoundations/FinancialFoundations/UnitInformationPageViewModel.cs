using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Queries;
using Functional;

namespace FinancialFoundations
{
    public class UnitInformationPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly UnitInformationPageViewModelConfiguration _configuration;
		private readonly IAsyncQueryHandler<GetAssignmentQuery, Result<Assignment, Exception>> _getAssignmentQueryHandler;

	    public UnitInformationPageViewModel(
		    UnitInformationPageViewModelConfiguration configuration,
		    IAsyncQueryHandler<GetAssignmentQuery, Result<Assignment, Exception>> getAssignmentQueryHandler)
	    {
		    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		    _getAssignmentQueryHandler = getAssignmentQueryHandler ?? throw new ArgumentNullException(nameof(getAssignmentQueryHandler));
	    }

		private int _currentPageNumber;
        public int CurrentPageNumber
        {
            set
            {
                if (_currentPageNumber != value)
                {
                    _currentPageNumber = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPageNumber"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
                }
            }
            get => _currentPageNumber;
        }

        public string Title => _configuration.PageCollection[_currentPageNumber].Title;
        public string Content => _configuration.PageCollection[_currentPageNumber].Content;

        public bool GoToPreviousPage()
        {
            if (CurrentPageNumber == 0)
            {
                return false;
            }
            CurrentPageNumber--;
            return true;
        }

        public bool GoToNextPage()
        {
            if (CurrentPageNumber == _configuration.PageCollection.Length - 1)
            {
                return false;
            }
            CurrentPageNumber++;
            return true;
        }

	    public async Task<Assignment> LoadAssignment(Guid educatorID, Guid associatedAssignmentID)
	    {
		    return (await _getAssignmentQueryHandler.Handle(new GetAssignmentQuery(educatorID, associatedAssignmentID))).EnsureSuccess();
	    }
    }
}

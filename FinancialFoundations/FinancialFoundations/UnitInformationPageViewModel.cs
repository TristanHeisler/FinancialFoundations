using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FinancialFoundations
{
    public class UnitInformationPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly UnitInformationPageViewModelConfiguration _configuration;

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

        public UnitInformationPageViewModel(UnitInformationPageViewModelConfiguration configuration)
        {
            _configuration = configuration;
        }

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
    }
}

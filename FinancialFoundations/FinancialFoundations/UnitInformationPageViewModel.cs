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
                    if (value == _configuration.PageCollection.Length)
                    {
                        Console.WriteLine("Show the assignment!");
                    }
                    else if(value >= 0)
                    {
                        _currentPageNumber = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPageNumber"));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
                    }
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
    }
}

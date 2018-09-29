using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FinancialFoundations
{
    public class UnitOverviewPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Guid _subjectMatterUnitID;

        private string _title;
        public string Title
        {
            set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
                }
            }
            get => _title;
        }
    }
}

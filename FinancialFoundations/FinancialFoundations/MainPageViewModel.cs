using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;
using FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.QueryHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FinancialFoundations
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GetSubjectMatterUnitTableOfContentsQueryHandler _tableOfContentsQueryHandler;

        private IEnumerable<SubjectMatterUnitTableOfContentsEntry> _tableOfContents;
        public IEnumerable<SubjectMatterUnitTableOfContentsEntry> TableOfContents
        {
            set
            {
                if (_tableOfContents != value)
                {
                    _tableOfContents = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TableOfContents"));
                }
            }
            get => _tableOfContents;
        }

        public MainPageViewModel(GetSubjectMatterUnitTableOfContentsQueryHandler tableOfContentsQueryHandler)
        {
            _tableOfContentsQueryHandler = tableOfContentsQueryHandler; 
        }

        public async Task LoadData()
        {
            TableOfContents = await _tableOfContentsQueryHandler.Handle(new GetSubjectMatterUnitTableOfContentsQuery(Guid.Parse("6c871eff-8f15-4233-987d-b54f559bd94d")));
        }
                     
        private string textToPresent;
        public string TextToPresent
        {
            set
            {
                if (textToPresent != value)
                {
                    textToPresent = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextToPresent"));
                }
            }
            get => textToPresent;
        }
    }
}

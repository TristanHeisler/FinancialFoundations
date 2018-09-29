using FinancialFoundations.Framework;
using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinancialFoundations
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IAsyncQueryHandler<GetSubjectMatterUnitTableOfContentsQuery, IEnumerable<SubjectMatterUnitTableOfContentsEntry>> _tableOfContentsQueryHandler;

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

        public MainPageViewModel(IAsyncQueryHandler<GetSubjectMatterUnitTableOfContentsQuery, IEnumerable<SubjectMatterUnitTableOfContentsEntry>> tableOfContentsQueryHandler)
        {
            _tableOfContentsQueryHandler = tableOfContentsQueryHandler;

            Task.Run(async () => { await LoadTableOfContents(); });
        }

        public async Task LoadTableOfContents()
        {
            TableOfContents = await _tableOfContentsQueryHandler.Handle(new GetSubjectMatterUnitTableOfContentsQuery(Guid.Empty));
        }
    }
}

using FinancialFoundations.Framework;
using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Functional;
using Xamarin.Forms;

namespace FinancialFoundations
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IAsyncQueryHandler<GetSubjectMatterUnitTableOfContentsQuery, Result<SubjectMatterUnitTableOfContents, Exception>> _tableOfContentsQueryHandler;
	    private readonly IAsyncQueryHandler<GetSubjectMatterUnitQuery, Result<SubjectMatterUnit, Exception>> _getSubjectMatterUnitQueryHandler;

	    public MainPageViewModel(
		    IAsyncQueryHandler<GetSubjectMatterUnitTableOfContentsQuery, Result<SubjectMatterUnitTableOfContents, Exception>> tableOfContentsQueryHandler,
		    IAsyncQueryHandler<GetSubjectMatterUnitQuery, Result<SubjectMatterUnit, Exception>> getSubjectMatterUnitQueryHandler)
	    {
		    _tableOfContentsQueryHandler = tableOfContentsQueryHandler ?? throw new ArgumentNullException(nameof(tableOfContentsQueryHandler));
		    _getSubjectMatterUnitQueryHandler = getSubjectMatterUnitQueryHandler ?? throw new ArgumentNullException(nameof(getSubjectMatterUnitQueryHandler));

		    Task.Run(async () => { await LoadTableOfContents(); });
	    }

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

        public async Task LoadTableOfContents()
        {
            TableOfContents = (await _tableOfContentsQueryHandler.Handle(new GetSubjectMatterUnitTableOfContentsQuery(Guid.Empty)))
	            .EnsureSuccess()
	            .EntryCollection;
        }

	    public async Task<SubjectMatterUnit> LoadSubjectMatterUnit(Guid subjectMatterID)
	    {
		    return (await _getSubjectMatterUnitQueryHandler.Handle(new GetSubjectMatterUnitQuery(Guid.Empty, subjectMatterID))).EnsureSuccess();
	    }
	}
}

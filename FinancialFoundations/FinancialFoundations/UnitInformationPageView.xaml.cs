using FinancialFoundations.SubjectMatter.Domain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FinancialFoundations
{
	public partial class UnitInformationPageView : ContentPage
	{
		private readonly Guid _associatedAssignmentID;

		public UnitInformationPageView(Guid subjectMatterUnitID, IEnumerable<SubjectMatterUnitPage> unitPages, Guid associatedAssignmentID)
		{
			_associatedAssignmentID = associatedAssignmentID;

            InitializeComponent();
            var container = new Container();
            container.RegisterDependencies();
            container.RegisterInstance(new UnitInformationPageViewModelConfiguration(subjectMatterUnitID, unitPages.ToArray(), associatedAssignmentID));
            BindingContext = container.GetInstance<UnitInformationPageViewModel>();
            ((UnitInformationPageViewModel)BindingContext).CurrentPageNumber = 0;
        }

        private async void ButtonPrevious_Clicked(object sender, EventArgs e)
        {
            if(!((UnitInformationPageViewModel)BindingContext).GoToPreviousPage())
            {
                await Navigation.PopToRootAsync();
            }
        }

        private async void ButtonNext_Clicked(object sender, EventArgs e)
        {
            if(!((UnitInformationPageViewModel)BindingContext).GoToNextPage())
            {
	            var assignment = await ((UnitInformationPageViewModel)BindingContext).LoadAssignment(Guid.Empty, _associatedAssignmentID);
				await Navigation.PushAsync(new AssignmentPageView(Guid.Empty, assignment));
            }
        }
    }
}

using FinancialFoundations.SubjectMatter.Domain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FinancialFoundations
{
	public partial class UnitInformationPageView : ContentPage
	{
		public UnitInformationPageView(Guid subjectMatterUnitID, List<SubjectMatterUnitPage> unitPages)
		{
            InitializeComponent();
            var container = new Container();
            container.RegisterDependencies();
            container.RegisterInstance(new UnitInformationPageViewModelConfiguration(subjectMatterUnitID, unitPages.ToArray()));
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
                await Navigation.PushAsync(new AssignmentPageView());
            }
        }
    }
}

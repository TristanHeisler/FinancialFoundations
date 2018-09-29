using FinancialFoundations.SubjectMatter.Domain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinancialFoundations
{
	public partial class MainPageView : ContentPage
	{
		public MainPageView()
		{
            InitializeComponent();
            var container = new Container();
            container.RegisterDependencies();
            BindingContext = container.GetInstance<MainPageViewModel>();
        }

        private async void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            var subjectMatterUnitID = ((SubjectMatterUnitTableOfContentsEntry)((BindableObject)sender).BindingContext).SubjectMatterUnitID;

            List<SubjectMatterUnitPage> unitPages = new List<SubjectMatterUnitPage>
            {
                new SubjectMatterUnitPage(Guid.Empty, subjectMatterUnitID, "Welcome", "This is the first page"),
                new SubjectMatterUnitPage(Guid.Empty, subjectMatterUnitID, "Second Page", "This is the second page"),
                new SubjectMatterUnitPage(Guid.Empty, subjectMatterUnitID, "Final Page", "This is the third page"),
            };

            await Navigation.PushAsync(new UnitInformationPageView(subjectMatterUnitID, unitPages));
        }
    }
}

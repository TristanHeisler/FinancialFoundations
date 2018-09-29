using FinancialFoundations.SubjectMatter.Domain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
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
	        var subjectMatterUnit = await ((MainPageViewModel) BindingContext).LoadSubjectMatterUnit(subjectMatterUnitID);

			await Navigation.PushAsync(new UnitInformationPageView(subjectMatterUnitID, subjectMatterUnit.PageCollection));
        }
    }
}

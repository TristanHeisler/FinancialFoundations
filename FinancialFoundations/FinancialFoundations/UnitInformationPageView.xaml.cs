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
		public UnitInformationPageView(Guid subjectMatterUnitID, IEnumerable<SubjectMatterUnitPage> unitPages)
		{
            InitializeComponent();
            var container = new Container();
            container.RegisterDependencies();
            container.RegisterInstance(new UnitInformationPageViewModelConfiguration(subjectMatterUnitID, unitPages.ToArray()));
            BindingContext = container.GetInstance<UnitInformationPageViewModel>();
            ((UnitInformationPageViewModel)BindingContext).CurrentPageNumber = 0;
        }

        private void ButtonPrevious_Clicked(object sender, EventArgs e)
        {
            ((UnitInformationPageViewModel)BindingContext).CurrentPageNumber--;
            Console.WriteLine("Prev");
        }

        private void ButtonNext_Clicked(object sender, EventArgs e)
        {
            ((UnitInformationPageViewModel)BindingContext).CurrentPageNumber++;
            Console.WriteLine("Next");
        }
    }
}

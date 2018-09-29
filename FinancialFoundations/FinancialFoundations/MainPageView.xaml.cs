﻿using FinancialFoundations.SubjectMatter.Domain;
using SimpleInjector;
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

        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            var x = "Tap event reached.";
        }
    }
}
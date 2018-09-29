using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinancialFoundations
{
	public partial class MainPageView : ContentPage
	{
		public MainPageView(MainPageViewModel viewModel)
		{
			InitializeComponent();
            BindingContext = viewModel;
        }
	}
}

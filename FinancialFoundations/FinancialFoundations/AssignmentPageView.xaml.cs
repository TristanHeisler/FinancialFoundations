using SimpleInjector;
using Xamarin.Forms;

namespace FinancialFoundations
{
	public partial class AssignmentPageView : ContentPage
	{
		public AssignmentPageView()
		{
            InitializeComponent();
            var container = new Container();
            container.RegisterDependencies();
            BindingContext = container.GetInstance<AssignmentPageViewModel>();
        }
    }
}

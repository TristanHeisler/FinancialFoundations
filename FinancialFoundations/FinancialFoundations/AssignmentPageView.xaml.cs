using FinancialFoundations.StudentWork.Domain;
using SimpleInjector;
using Xamarin.Forms;

namespace FinancialFoundations
{
	public partial class AssignmentPageView : ContentPage
	{
		public AssignmentPageView(Assignment assignment)
		{
            InitializeComponent();
			var configuration = new AssignmentPageViewModelConfiguration(assignment);
            var container = new Container();
            container.RegisterDependencies();
			container.RegisterInstance(configuration);
            BindingContext = container.GetInstance<AssignmentPageViewModel>();
        }
    }
}

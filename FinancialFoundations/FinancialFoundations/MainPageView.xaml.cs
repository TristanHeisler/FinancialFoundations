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
    }
}

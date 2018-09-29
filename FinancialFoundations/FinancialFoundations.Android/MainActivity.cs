using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FinancialFoundations.Framework;
using SimpleInjector;

namespace FinancialFoundations.Droid
{
	[Activity(Label = "FinancialFoundations", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			var assembliesToScan = new[]
			{
				typeof(StudentWork.Implementation.LocalFileStorage.AssemblyMarker).Assembly,
				typeof(SubjectMatter.Implementation.LocalFileStorage.AssemblyMarker).Assembly
			};

			var container = new Container();
			container.Register(typeof(IAsyncQueryHandler<,>), assembliesToScan);
			container.Register(typeof(IAsyncCommandHandler<,>), assembliesToScan);

			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			// TODO: instantiate the application with all dependencies registered
			LoadApplication(new App());
		}
	}
}
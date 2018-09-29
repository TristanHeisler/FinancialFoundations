using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FinancialFoundations.Framework;
using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;
using FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels;
using Newtonsoft.Json;
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

			// the user needs to specifically grant permissions to the application
			var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
			RequestPermissions(permissions, 77);

			var assembliesToScan = new[]
			{
				typeof(StudentWork.Implementation.LocalFileStorage.AssemblyMarker).Assembly,
				typeof(SubjectMatter.Implementation.LocalFileStorage.AssemblyMarker).Assembly
			};

			var container = new Container();
			container.Register(typeof(IAsyncQueryHandler<,>), assembliesToScan);
			container.Register(typeof(IAsyncCommandHandler<,>), assembliesToScan);

			var educatorID = Guid.Empty;
			var tableOfContentsFileName = new SubjectMatterUnitTableOfContentsFileInfo(educatorID).ToFilePath();
			if (!File.Exists(tableOfContentsFileName))
			{
				var jsonContents = JsonConvert.SerializeObject(new SubjectMatterUnitTableOfContents(educatorID, new[]
				{
					new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Unit 1", false),
					new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Unit 2", false),
					new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Unit 3", false)
				}));
				File.WriteAllText(tableOfContentsFileName, jsonContents, Encoding.UTF8);
			}

			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			// TODO: instantiate the application with all dependencies registered
			LoadApplication(new App());
		}
	}
}
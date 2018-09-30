using System;
using System.IO;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels;
using FinancialFoundations.SubjectMatter.Domain;
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
			var tableOfContents = new SubjectMatterUnitTableOfContents(educatorID, new[]
			{
				new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Retirement", false),
				new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Investment", false),
				new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Mortages", false),
                new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Banking", false),
                new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Goal-Setting", false),
                new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Credit Cards", false)
            });
			var tableOfContentsJsonContents = JsonConvert.SerializeObject(tableOfContents.ToSubjectMatterUnitTableOfContentsSpecification());
			File.WriteAllText(tableOfContentsFileName, tableOfContentsJsonContents, Encoding.UTF8);

			foreach (var subjectMatterUnit in tableOfContents.EntryCollection)
			{
				var subjectMatterUnitFileName = new SubjectMatterUnitFileInfo(educatorID, subjectMatterUnit.SubjectMatterUnitID).ToFilePath();
				if (File.Exists(subjectMatterUnitFileName))
					continue;

				var assignmentID = Guid.NewGuid();
				var unitJsonContents = JsonConvert.SerializeObject(new SubjectMatterUnit(educatorID, subjectMatterUnit.SubjectMatterUnitID, new[]
				{
					new SubjectMatterUnitPage(educatorID, subjectMatterUnit.SubjectMatterUnitID, "Choosing a credit card", "You should look for:\n\tCost of borrowing (APR)\n\tMinimum payment\n\tAnnual fee\n\tOverdraft charges\n\tRewards/cashback"),
					new SubjectMatterUnitPage(educatorID, subjectMatterUnit.SubjectMatterUnitID, "Housing", "Evaluate available housing alternatives.\n\n Evaluate your needs, life situation and financial resources.\n\n Assess renting and buying alternatives."),
                    new SubjectMatterUnitPage(educatorID, subjectMatterUnit.SubjectMatterUnitID, "Retirement", "Successful, happy retirement takes proper planning and evaluation. Planning helps us anticipate future changes while gaining control over our future.\n\nRetirement planning is the planning one does to be prepared for life after paid work ends. The goal of retirement planning is to achieve financial independence.")
				}, assignmentID).ToSubjectMatterUnitSpecification());
				File.WriteAllText(subjectMatterUnitFileName, unitJsonContents, Encoding.UTF8);

				var questionIDCollection = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
				var assignmentFileName = new AssignmentFileInfo(educatorID, assignmentID).ToFilePath();
				var assignmentJsonContents = JsonConvert.SerializeObject(new AssignmentDataSpecification
				{
					EducatorID = educatorID,
					AssignmentID = assignmentID,
					MultipleChoiceQuestionIDCollection = questionIDCollection
				});
				File.WriteAllText(assignmentFileName, assignmentJsonContents, Encoding.UTF8);

				foreach (var questionID in questionIDCollection)
				{
					var correctAnswerID = Guid.NewGuid();
					var questionSpecification = new AssignmentMultipleChoiceQuestionDataSpecification
					{
						EducatorID = educatorID,
						AssignmentID = assignmentID,
						QuestionID = questionID,
						QuestionText = "Which topic was not covered in this presentation?",
						AnswerIDCollection = new[] { correctAnswerID, Guid.NewGuid(), Guid.NewGuid() }.OrderBy(x => x).ToArray(),
						CorrectAnswerID = correctAnswerID
					};
					var questionFileName = new AssignmentMultipleChoiceQuestionFileInfo(educatorID, assignmentID, questionID).ToFilePath();
					var questionJsonContents = JsonConvert.SerializeObject(questionSpecification);
					File.WriteAllText(questionFileName, questionJsonContents, Encoding.UTF8);

					foreach (var answerID in questionSpecification.AnswerIDCollection)
					{
						var answerFileName = new AssignmentMultipleChoiceQuestionAnswerFileInfo(educatorID, assignmentID, questionID, answerID).ToFilePath();
                        var answerJsonContents = JsonConvert.SerializeObject(new AssignmentMultipleChoiceQuestionAnswerDataSpecification
                        {
                            EducatorID = educatorID,
                            AssignmentID = assignmentID,
                            QuestionID = questionID,
                            AnswerID = answerID,
                            AnswerText = "Placeholder Answer"
						});
						File.WriteAllText(answerFileName, answerJsonContents, Encoding.UTF8);
					}
				}
			}
			
			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			// TODO: instantiate the application with all dependencies registered
			LoadApplication(new App());
		}
	}
}
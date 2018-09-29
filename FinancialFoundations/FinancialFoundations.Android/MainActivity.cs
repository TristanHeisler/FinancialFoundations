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
				new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Unit 1", false),
				new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Unit 2", false),
				new SubjectMatterUnitTableOfContentsEntry(Guid.NewGuid(), "Unit 3", false)
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
					new SubjectMatterUnitPage(educatorID, subjectMatterUnit.SubjectMatterUnitID, "Page 1"),
					new SubjectMatterUnitPage(educatorID, subjectMatterUnit.SubjectMatterUnitID, "Page 2"),
					new SubjectMatterUnitPage(educatorID, subjectMatterUnit.SubjectMatterUnitID, "Page 3")
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
						QuestionText = "",
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
							AnswerText = ""
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
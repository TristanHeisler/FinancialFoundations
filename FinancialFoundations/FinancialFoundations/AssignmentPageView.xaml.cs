using System;
using System.Threading.Tasks;
using FinancialFoundations.Models;
using FinancialFoundations.StudentWork.Domain;
using Functional;
using SimpleInjector;
using Xamarin.Forms;

namespace FinancialFoundations
{
	public partial class AssignmentPageView : ContentPage
	{
		public AssignmentPageView(Guid studentID, Assignment assignment)
		{
            InitializeComponent();
			var configuration = new AssignmentPageViewModelConfiguration(studentID, assignment);
            var container = new Container();
            container.RegisterDependencies();
			container.RegisterInstance(configuration);
            BindingContext = container.GetInstance<AssignmentPageViewModel>();
        }

		private AssignmentPageViewModel ViewModel => ((AssignmentPageViewModel) BindingContext);

		private async void Button_OnClicked(object sender, EventArgs e)
		{
			await ViewModel.AssignmentData.ToStudentAssignmentSubmission().ApplyAsync(DisplayGrade, ShowAssignmentNotCompleted);
			await Navigation.PopToRootAsync();
		}

		private async Task DisplayGrade(StudentAssignmentSubmission completedAssignment)
		{
			var grade = await ViewModel.GradeAssignment(completedAssignment);
			await DisplayAlert("Assignment Submitted", $"{grade.NumberOfCorrectAnswers} / {grade.NumberOfQuestions}", "OK");
		}

		private async Task ShowAssignmentNotCompleted()
		{
			await DisplayAlert("Assignment Not Completed", $"Please complete the assignment.", "OK");
		}
	}
}

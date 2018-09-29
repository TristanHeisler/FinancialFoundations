using FinancialFoundations.StudentWork.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using FinancialFoundations.Extensions;
using FinancialFoundations.Framework;
using FinancialFoundations.Models;
using FinancialFoundations.StudentWork.CoreProcessing;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Queries;
using Functional;

namespace FinancialFoundations
{
    public class AssignmentPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

	    private readonly AssignmentPageViewModelConfiguration _configuration;
	    private readonly IAsyncQueryHandler<GetAssignmentAnswerKeyQuery, Result<AssignmentAnswerKey, Exception>> _getAssignmentAsyncQueryHandler;

	    public AssignmentPageViewModel(
		    AssignmentPageViewModelConfiguration configuration,
		    IAsyncQueryHandler<GetAssignmentAnswerKeyQuery, Result<AssignmentAnswerKey, Exception>> getAssignmentAsyncQueryHandler)
	    {
		    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		    _getAssignmentAsyncQueryHandler = getAssignmentAsyncQueryHandler ?? throw new ArgumentNullException(nameof(getAssignmentAsyncQueryHandler));

		    AssignmentData = configuration.Assignment.ToAssignmentInProgress(configuration.StudentID);
	    }

	    public StudentAssignmentInProgress AssignmentData { get; }

	    public async Task<StudentGrade> GradeAssignment(StudentAssignmentSubmission completedAssignment)
	    {
		    var answerKey = (await _getAssignmentAsyncQueryHandler.Handle(new GetAssignmentAnswerKeyQuery(completedAssignment.EducatorID, completedAssignment.AssignmentID))).EnsureSuccess();
		    return new StudentGradeSubmissionBundle(answerKey, completedAssignment).ComputeGrade();
        }

        public IEnumerable<AssignmentMultipleChoiceQuestion> MultipleChoiceQuestionCollection => _configuration.Assignment.MultipleChoiceQuestionCollection;
    }
}

﻿using FinancialFoundations.StudentWork.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialFoundations.Extensions;
using FinancialFoundations.Framework;
using FinancialFoundations.Models;
using FinancialFoundations.StudentWork.CoreProcessing;
using System.Collections.Generic;
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

        public IEnumerable<AssignmentMultipleChoiceQuestionForDisplay> MultipleChoiceQuestionCollection => _configuration.Assignment.MultipleChoiceQuestionCollection.Select(x => new AssignmentMultipleChoiceQuestionForDisplay(x)).ToArray();
    }

    public class AssignmentMultipleChoiceQuestionForDisplay
    {
        public AssignmentMultipleChoiceQuestionForDisplay(AssignmentMultipleChoiceQuestion source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            QuestionID = source.QuestionID;
            QuestionText = source.QuestionText ?? throw new ArgumentNullException(nameof(source.QuestionText));
            AnswerCollection = source.AnswerCollection?.Select(x => new AssignmentMultipleChoiceQuestionAnswerForDisplay(source.QuestionID, x)).ToList() ?? throw new ArgumentNullException(nameof(source.AnswerCollection));
        }

        public Guid QuestionID { get; }
        public string QuestionText { get; }
        public IList<AssignmentMultipleChoiceQuestionAnswerForDisplay> AnswerCollection { get; }
    }

    public class AssignmentMultipleChoiceQuestionAnswerForDisplay
    {
        public AssignmentMultipleChoiceQuestionAnswerForDisplay(Guid questionID, AssignmentMultipleChoiceQuestionAnswer source)
        {
            QuestionID = questionID;
            AnswerID = source.AnswerID;
            AnswerText = source.AnswerText ?? throw new ArgumentNullException(nameof(source.AnswerText));
        }

        public Guid QuestionID { get; }
        public Guid AnswerID { get; }
        public string AnswerText { get; }

        public override string ToString() => AnswerText;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.CoreProcessing;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Queries;
using Functional;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetStudentGradeForAssignmentQueryHandler : IAsyncQueryHandler<GetStudentGradeForAssignmentQuery, Result<StudentGrade, Exception>>
	{
		private readonly IAsyncQueryHandler<GetAssignmentAnswerKeyQuery, Result<AssignmentAnswerKey, Exception>> _getAssignmentAnswerKeyQueryHandler;
		private readonly IAsyncQueryHandler<GetStudentSubmissionForAssignmentQuery, Result<StudentAssignmentSubmission, Exception>> _getStudentSubmissionForAssignmentQueryHandler;

		public GetStudentGradeForAssignmentQueryHandler(
			IAsyncQueryHandler<GetAssignmentAnswerKeyQuery, Result<AssignmentAnswerKey, Exception>> getAssignmentAnswerKeyQueryHandler,
			IAsyncQueryHandler<GetStudentSubmissionForAssignmentQuery, Result<StudentAssignmentSubmission, Exception>> getStudentSubmissionForAssignmentQueryHandler)
		{
			_getAssignmentAnswerKeyQueryHandler = getAssignmentAnswerKeyQueryHandler ?? throw new ArgumentNullException(nameof(getAssignmentAnswerKeyQueryHandler));
			_getStudentSubmissionForAssignmentQueryHandler = getStudentSubmissionForAssignmentQueryHandler ?? throw new ArgumentNullException(nameof(getStudentSubmissionForAssignmentQueryHandler));
		}

		public async Task<Result<StudentGrade, Exception>> Handle(GetStudentGradeForAssignmentQuery parameters)
		{
			return await _getAssignmentAnswerKeyQueryHandler.Handle(new GetAssignmentAnswerKeyQuery(parameters.EducatorID, parameters.AssignmentID))
				.MapFailure(exception => new Exception("An error occurred while retrieving assignment answer key!", exception))
				.BindAsync(answerKey => 
					_getStudentSubmissionForAssignmentQueryHandler.Handle(new GetStudentSubmissionForAssignmentQuery(parameters.EducatorID, parameters.AssignmentID, parameters.StudentID))
						.Select(submission => new StudentGradeSubmissionBundle(answerKey, submission))
						.MapFailure(exception => new Exception("An error occurred while retrieving student submission!", exception)))
				.Select(bundle => bundle.ComputeGrade());
		}
	}
}

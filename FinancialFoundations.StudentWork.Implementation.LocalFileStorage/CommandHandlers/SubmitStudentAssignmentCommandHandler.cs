using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.CoreProcessing;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Commands;
using FinancialFoundations.StudentWork.Domain.Queries;
using Functional;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.CommandHandlers
{
	public class SubmitStudentAssignmentCommandHandler : IAsyncCommandHandler<SubmitStudentAssignmentCommand, SubmitStudentAssignmentCommandError>
	{
		private readonly IAsyncQueryHandler<GetAssignmentAnswerKeyQuery, Result<AssignmentAnswerKey, Exception>> _getAssignmentAnswerKeyQueryHandler;

		public SubmitStudentAssignmentCommandHandler(IAsyncQueryHandler<GetAssignmentAnswerKeyQuery, Result<AssignmentAnswerKey, Exception>> getAssignmentAnswerKeyQueryHandler)
		{
			_getAssignmentAnswerKeyQueryHandler = getAssignmentAnswerKeyQueryHandler;
		}

		public async Task<Result<Unit, SubmitStudentAssignmentCommandError>> Handle(SubmitStudentAssignmentCommand parameters)
		{
			return await _getAssignmentAnswerKeyQueryHandler.Handle(new GetAssignmentAnswerKeyQuery(parameters.Data.EducatorID, parameters.Data.AssignmentID))
				.Select(answerKey => new StudentGradeSubmissionBundle(answerKey, parameters.Data).ComputeGrade())
				.BindAsync(x => WriteAssignmentSubmission(parameters.Data.EducatorID, parameters.Data.AssignmentID, parameters.Data.StudentID, x))
				.MapFailure(exception => new SubmitStudentAssignmentCommandError(exception));
		}

		private static async Task<Result<Unit, Exception>> WriteAssignmentSubmission(Guid educatorID, Guid assignmentID, Guid studentID, StudentGrade studentGrade)
		{
			await Task.Delay(1000);
			return Result.Try(() =>
				{

					return Unit.Value;
				});
		}
	}
}

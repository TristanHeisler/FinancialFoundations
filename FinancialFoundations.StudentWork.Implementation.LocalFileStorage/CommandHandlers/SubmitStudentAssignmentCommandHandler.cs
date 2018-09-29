using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Commands;
using FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels;
using Functional;
using Newtonsoft.Json;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.CommandHandlers
{
	public class SubmitStudentAssignmentCommandHandler : IAsyncCommandHandler<SubmitStudentAssignmentCommand, SubmitStudentAssignmentCommandError>
	{
		public async Task<Result<Unit, SubmitStudentAssignmentCommandError>> Handle(SubmitStudentAssignmentCommand parameters)
		{
			return await WriteAssignmentSubmission(parameters.Data)
				.MapFailure(exception => new SubmitStudentAssignmentCommandError(exception));
		}

		private static async Task<Result<Unit, Exception>> WriteAssignmentSubmission(StudentAssignmentSubmission data)
		{
			await Task.Delay(1000);
			return Result.Try(() =>
			{
				var jsonContents = JsonConvert.SerializeObject(data.ToStudentAssignmentSubmissionDataSpecification());
				File.WriteAllText(new StudentAssignmentSubmissionFileInfo(data.EducatorID, data.AssignmentID, data.StudentID).ToFilePath(), jsonContents, Encoding.UTF8);
				return Unit.Value;
			});
		}
	}
}

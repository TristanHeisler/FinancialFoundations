using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Queries;
using FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels;
using Functional;
using Newtonsoft.Json;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetStudentSubmissionForAssignmentQueryHandler : IAsyncQueryHandler<GetStudentSubmissionForAssignmentQuery, Result<StudentAssignmentSubmission, Exception>>
	{
		public async Task<Result<StudentAssignmentSubmission, Exception>> Handle(GetStudentSubmissionForAssignmentQuery parameters)
		{
			await Task.Delay(1000);

			return Result.Try(() =>
			{
				var jsonFileContents = File.ReadAllText(new StudentAssignmentSubmissionFileInfo(parameters.EducatorID, parameters.AssignmentID, parameters.StudentID).ToFilePath());
				var assignmentDataSpecification = JsonConvert.DeserializeObject<StudentAssignmentSubmissionDataSpecification>(jsonFileContents);

				return new StudentAssignmentSubmission(assignmentDataSpecification.EducatorID, assignmentDataSpecification.AssignmentID, assignmentDataSpecification.StudentID, assignmentDataSpecification.AnswerCollection.Select(x => x.ToStudentAssignmentSubmissionMultipleChoiceQuestionAnswer()).ToArray());
			});
		}
	}
}
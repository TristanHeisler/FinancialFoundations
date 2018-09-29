using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Queries;
using FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels;
using Functional;
using Newtonsoft.Json;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetAssignmentAnswerKeyQueryHandler : IAsyncQueryHandler<GetAssignmentAnswerKeyQuery, Result<AssignmentAnswerKey, Exception>>
	{
		public async Task<Result<AssignmentAnswerKey, Exception>> Handle(GetAssignmentAnswerKeyQuery parameters)
		{
			await Task.Delay(1000);

			return Result.Try(() =>
			{
				var jsonFileContents = File.ReadAllText(new AssignmentFileInfo(parameters.EducatorID, parameters.AssignmentID).ToFilePath());
				var assignmentDataSpecification = JsonConvert.DeserializeObject<AssignmentDataSpecification>(jsonFileContents);
				var multipleChoiceQuestionAnswerKeyCollection = assignmentDataSpecification.MultipleChoiceQuestionIDCollection.Select(questionID =>
				{
					var multipleChoiceQuestionJsonFileContents = File.ReadAllText(new AssignmentMultipleChoiceQuestionFileInfo(parameters.EducatorID, parameters.AssignmentID, questionID).ToFilePath());
					var multipleChoiceQuestionDataSpecification = JsonConvert.DeserializeObject<AssignmentMultipleChoiceQuestionDataSpecification>(multipleChoiceQuestionJsonFileContents);

					return new AssignmentAnswerKeyMultipleChoiceQuestionAnswer(multipleChoiceQuestionDataSpecification.QuestionID, multipleChoiceQuestionDataSpecification.CorrectAnswerID);
				});

				return new AssignmentAnswerKey(assignmentDataSpecification.EducatorID, assignmentDataSpecification.AssignmentID, multipleChoiceQuestionAnswerKeyCollection);
			});
		}
	}
}

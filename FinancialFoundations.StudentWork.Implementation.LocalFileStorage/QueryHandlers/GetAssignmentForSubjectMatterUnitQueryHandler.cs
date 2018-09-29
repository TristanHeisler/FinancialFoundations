using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.StudentWork.Domain;
using FinancialFoundations.StudentWork.Domain.Queries;
using FinancialFoundations.StudentWork.Implementation.LocalFileStorage.FileModels;
using Newtonsoft.Json;

namespace FinancialFoundations.StudentWork.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetAssignmentForSubjectMatterUnitQueryHandler : IAsyncQueryHandler<GetAssignmentQuery, Assignment>
	{
		public async Task<Assignment> Handle(GetAssignmentQuery parameters)
		{
			// fake retrieving from the web...
			await Task.Delay(1000);

			var jsonFileContents = File.ReadAllText(new AssignmentFileInfo(parameters.EducatorID, parameters.AssignmentID).ToFilePath());
			var assignmentDataSpecification = JsonConvert.DeserializeObject<AssignmentDataSpecification>(jsonFileContents);
			var multipleChoiceQuestionCollection = assignmentDataSpecification.MultipleChoiceQuestionIDCollection.Select(questionID =>
			{
				var multipleChoiceQuestionJsonFileContents = File.ReadAllText(new AssignmentMultipleChoiceQuestionFileInfo(parameters.EducatorID, parameters.AssignmentID, questionID).ToFilePath());
				var multipleChoiceQuestionDataSpecification = JsonConvert.DeserializeObject<AssignmentMultipleChoiceQuestionDataSpecification>(multipleChoiceQuestionJsonFileContents);
				var answerCollection = multipleChoiceQuestionDataSpecification.AnswerIDCollection.Select(answerID =>
				{
					var answerJsonFileContents = File.ReadAllText(new AssignmentMultipleChoiceQuestionAnswerFileInfo(parameters.EducatorID, parameters.AssignmentID, questionID, answerID).ToFilePath());
					var answerDataSpecification = JsonConvert.DeserializeObject<AssignmentMultipleChoiceQuestionAnswerDataSpecification>(answerJsonFileContents);
					
					return new AssignmentMultipleChoiceQuestionAnswer(answerDataSpecification.AnswerID, answerDataSpecification.AnswerText);
				});

				return new AssignmentMultipleChoiceQuestion(multipleChoiceQuestionDataSpecification.QuestionID, multipleChoiceQuestionDataSpecification.QuestionText, answerCollection);
			});

			return new Assignment(assignmentDataSpecification.EducatorID, assignmentDataSpecification.AssignmentID, multipleChoiceQuestionCollection);
		}
	}
}

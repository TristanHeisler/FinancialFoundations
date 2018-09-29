using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;
using FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels;
using Functional;
using Newtonsoft.Json;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetSubjectMatterUnitTableOfContentsQueryHandler : IAsyncQueryHandler<GetSubjectMatterUnitTableOfContentsQuery, Result<SubjectMatterUnitTableOfContents, Exception>>
	{
		public async Task<Result<SubjectMatterUnitTableOfContents, Exception>> Handle(GetSubjectMatterUnitTableOfContentsQuery parameters)
		{
			await Task.Delay(1000);

			return Result.Try(() =>
			{
				var jsonFileContents = File.ReadAllText(new SubjectMatterUnitTableOfContentsFileInfo(parameters.EducatorID).ToFilePath());
				return JsonConvert.DeserializeObject<SubjectMatterUnitTableOfContentsDataSpecification>(jsonFileContents).ToSubjectMatterUnitTableOfContents();
			});
		}
	}
}

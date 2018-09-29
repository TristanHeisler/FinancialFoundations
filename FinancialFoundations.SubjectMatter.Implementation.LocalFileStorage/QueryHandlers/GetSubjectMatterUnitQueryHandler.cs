using System;
using System.IO;
using System.Threading.Tasks;
using FinancialFoundations.Framework;
using FinancialFoundations.SubjectMatter.Domain;
using FinancialFoundations.SubjectMatter.Domain.Queries;
using FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels;
using Newtonsoft.Json;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.QueryHandlers
{
	public class GetSubjectMatterUnitQueryHandler : IAsyncQueryHandler<GetSubjectMatterUnitQuery, SubjectMatterUnit>
	{
		public async Task<SubjectMatterUnit> Handle(GetSubjectMatterUnitQuery parameters)
		{
			await Task.Delay(1000);

			var jsonFileContents = File.ReadAllText(new SubjectMatterUnitFileInfo(parameters.EducatorID, parameters.SubjectMatterID).ToFilePath());
			return JsonConvert.DeserializeObject<SubjectMatterUnitDataSpecification>(jsonFileContents).ToSubjectMatterUnit();
		}
	}
}
using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public class SubjectMatterUnitFileInfo
	{
		public SubjectMatterUnitFileInfo(Guid educatorID, Guid subjectMatterUnitID)
		{
			EducatorID = educatorID;
			SubjectMatterUnitID = subjectMatterUnitID;
		}

		public Guid EducatorID { get; }
		public Guid SubjectMatterUnitID { get; }
	}
}
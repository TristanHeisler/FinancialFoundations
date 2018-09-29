using System;

namespace FinancialFoundations.SubjectMatter.Implementation.LocalFileStorage.FileModels
{
	public class SubjectMatterUnitTableOfContentsFileInfo
	{
		public SubjectMatterUnitTableOfContentsFileInfo(Guid educatorID)
		{
			EducatorID = educatorID;
		}

		public Guid EducatorID { get; }
	}
}

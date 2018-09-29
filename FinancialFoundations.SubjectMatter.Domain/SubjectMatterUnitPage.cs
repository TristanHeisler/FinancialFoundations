using System;

namespace FinancialFoundations.SubjectMatter.Domain
{
	public class SubjectMatterUnitPage
	{
		public SubjectMatterUnitPage(Guid educatorID, Guid subjectMatterUnitID, string title, string content)
		{
			EducatorID = educatorID;
			SubjectMatterUnitID = subjectMatterUnitID;
            Title = title;
			Content = content ?? throw new ArgumentNullException(nameof(content));
		}

		public Guid EducatorID { get; }
		public Guid SubjectMatterUnitID { get; }
        public string Title { get; }
		public string Content { get; }
	}
}
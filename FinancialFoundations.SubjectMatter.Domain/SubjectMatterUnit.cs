using System;
using System.Collections.Generic;

namespace FinancialFoundations.SubjectMatter.Domain
{
	public class SubjectMatterUnit
	{
		public SubjectMatterUnit(Guid educatorID, Guid subjectMatterUnitID, IEnumerable<SubjectMatterUnitPage> pageCollection, Guid associatedAssignmentID)
		{
			EducatorID = educatorID;
			SubjectMatterUnitID = subjectMatterUnitID;
			PageCollection = pageCollection ?? throw new ArgumentNullException(nameof(pageCollection));
			AssociatedAssignmentID = associatedAssignmentID;
		}

		public Guid EducatorID { get; }
		public Guid SubjectMatterUnitID { get; }
		public IEnumerable<SubjectMatterUnitPage> PageCollection { get; }
		public Guid AssociatedAssignmentID { get; }
	}
}
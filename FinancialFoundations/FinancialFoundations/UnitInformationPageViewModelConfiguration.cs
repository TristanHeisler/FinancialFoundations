using FinancialFoundations.SubjectMatter.Domain;
using System;

namespace FinancialFoundations
{
    public class UnitInformationPageViewModelConfiguration
    {
        public UnitInformationPageViewModelConfiguration(Guid subjectMatterUnitID, SubjectMatterUnitPage[] pageCollection, Guid associatedAssignmentID)
        {
            SubjectMatterUnitID = subjectMatterUnitID;
            PageCollection = pageCollection;
	        AssociatedAssignmentID = associatedAssignmentID;
        }
        
        public Guid SubjectMatterUnitID { get; }
        public SubjectMatterUnitPage[] PageCollection { get; }
		public Guid AssociatedAssignmentID { get; }
    }
 }

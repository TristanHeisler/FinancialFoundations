using FinancialFoundations.SubjectMatter.Domain;
using System;

namespace FinancialFoundations
{
    public class UnitInformationPageViewModelConfiguration
    {
        public UnitInformationPageViewModelConfiguration(Guid subjectMatterUnitID, SubjectMatterUnitPage[] pageCollection)
        {
            SubjectMatterUnitID = subjectMatterUnitID;
            PageCollection = pageCollection;
        }
        
        public Guid SubjectMatterUnitID { get; }
        public SubjectMatterUnitPage[] PageCollection { get; }
    }
 }

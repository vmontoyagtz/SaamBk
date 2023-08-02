using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorApplicant : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AdvisorApplicant() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorApplicant(Guid advisorApplicantId, Guid regionAreaAdvisorCategoryId, int yearsOfExperience,
            bool approved, string? applicantNotes, int stage, Guid tenantId)
        {
            AdvisorApplicantId = Guard.Against.NullOrEmpty(advisorApplicantId, nameof(advisorApplicantId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            YearsOfExperience = Guard.Against.NegativeOrZero(yearsOfExperience, nameof(yearsOfExperience));
            Approved = Guard.Against.Null(approved, nameof(approved));
            ApplicantNotes = applicantNotes;
            Stage = Guard.Against.NegativeOrZero(stage, nameof(stage));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AdvisorApplicantId { get; private set; }

        public int YearsOfExperience { get; private set; }

        public bool Approved { get; private set; }

        public string? ApplicantNotes { get; private set; }

        public int Stage { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }


        public void UpdateRegionAreaAdvisorCategoryForAdvisorApplicant(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var advisorApplicantUpdatedEvent = new AdvisorApplicantUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorApplicantUpdatedEvent);
        }

        public void SetApplicantNotes(string applicantNotes)
        {
            ApplicantNotes = applicantNotes;
        }
    }
}
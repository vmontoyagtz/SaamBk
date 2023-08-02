using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorApplicantDto
    {
        public AdvisorApplicantDto() { } // AutoMapper required

        public AdvisorApplicantDto(Guid advisorApplicantId, Guid regionAreaAdvisorCategoryId, int yearsOfExperience,
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

        public Guid AdvisorApplicantId { get; set; }

        [Required(ErrorMessage = "Years Of Experience is required")]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Approved is required")]
        public bool Approved { get; set; }

        [MaxLength(100)] public string? ApplicantNotes { get; set; }

        [Required(ErrorMessage = "Stage is required")]
        public int Stage { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class UpdateAdvisorApplicantRequest : BaseRequest
    {
        public Guid AdvisorApplicantId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public int YearsOfExperience { get; set; }
        public bool Approved { get; set; }
        public string? ApplicantNotes { get; set; }
        public int Stage { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAdvisorApplicantRequest FromDto(AdvisorApplicantDto advisorApplicantDto)
        {
            return new UpdateAdvisorApplicantRequest
            {
                AdvisorApplicantId = advisorApplicantDto.AdvisorApplicantId,
                RegionAreaAdvisorCategoryId = advisorApplicantDto.RegionAreaAdvisorCategoryId,
                YearsOfExperience = advisorApplicantDto.YearsOfExperience,
                Approved = advisorApplicantDto.Approved,
                ApplicantNotes = advisorApplicantDto.ApplicantNotes,
                Stage = advisorApplicantDto.Stage,
                TenantId = advisorApplicantDto.TenantId
            };
        }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class CreateAdvisorApplicantRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public int YearsOfExperience { get; set; }
        public bool Approved { get; set; }
        public string? ApplicantNotes { get; set; }
        public int Stage { get; set; }
        public Guid TenantId { get; set; }
    }
}
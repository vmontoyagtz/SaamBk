using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class DeleteAdvisorApplicantRequest : BaseRequest
    {
        public Guid AdvisorApplicantId { get; set; }
    }
}
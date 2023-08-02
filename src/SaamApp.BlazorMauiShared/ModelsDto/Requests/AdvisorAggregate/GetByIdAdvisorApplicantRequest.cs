using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class GetByIdAdvisorApplicantRequest : BaseRequest
    {
        public Guid AdvisorApplicantId { get; set; }
    }
}
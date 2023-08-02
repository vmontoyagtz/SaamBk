using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class UpdateAdvisorApplicantResponse : BaseResponse
    {
        public UpdateAdvisorApplicantResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorApplicantResponse()
        {
        }

        public AdvisorApplicantDto AdvisorApplicant { get; set; } = new();
    }
}
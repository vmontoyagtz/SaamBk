using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class CreateAdvisorApplicantResponse : BaseResponse
    {
        public CreateAdvisorApplicantResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorApplicantResponse()
        {
        }

        public AdvisorApplicantDto AdvisorApplicant { get; set; } = new();
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class GetByIdAdvisorApplicantResponse : BaseResponse
    {
        public GetByIdAdvisorApplicantResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorApplicantResponse()
        {
        }

        public AdvisorApplicantDto AdvisorApplicant { get; set; } = new();
    }
}
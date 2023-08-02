using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class ListAdvisorApplicantResponse : BaseResponse
    {
        public ListAdvisorApplicantResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorApplicantResponse()
        {
        }

        public List<AdvisorApplicantDto> AdvisorApplicants { get; set; } = new();

        public int Count { get; set; }
    }
}
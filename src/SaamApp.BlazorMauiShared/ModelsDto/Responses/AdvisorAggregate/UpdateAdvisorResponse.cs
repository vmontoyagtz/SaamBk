using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class UpdateAdvisorResponse : BaseResponse
    {
        public UpdateAdvisorResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorResponse()
        {
        }

        public AdvisorDto Advisor { get; set; } = new();
    }
}
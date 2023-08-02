using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class GetByIdAdvisorResponse : BaseResponse
    {
        public GetByIdAdvisorResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorResponse()
        {
        }

        public AdvisorDto Advisor { get; set; } = new();
    }
}
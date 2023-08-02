using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class CreateAdvisorResponse : BaseResponse
    {
        public CreateAdvisorResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorResponse()
        {
        }

        public AdvisorDto Advisor { get; set; } = new();
    }
}
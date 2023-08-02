using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class CreateFaqResponse : BaseResponse
    {
        public CreateFaqResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateFaqResponse()
        {
        }

        public FaqDto Faq { get; set; } = new();
    }
}
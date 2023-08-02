using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class UpdateFaqResponse : BaseResponse
    {
        public UpdateFaqResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateFaqResponse()
        {
        }

        public FaqDto Faq { get; set; } = new();
    }
}
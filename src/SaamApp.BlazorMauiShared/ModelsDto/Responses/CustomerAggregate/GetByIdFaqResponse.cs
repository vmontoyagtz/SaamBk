using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class GetByIdFaqResponse : BaseResponse
    {
        public GetByIdFaqResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdFaqResponse()
        {
        }

        public FaqDto Faq { get; set; } = new();
    }
}
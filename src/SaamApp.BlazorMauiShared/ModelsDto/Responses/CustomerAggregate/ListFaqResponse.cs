using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class ListFaqResponse : BaseResponse
    {
        public ListFaqResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListFaqResponse()
        {
        }

        public List<FaqDto> Faqs { get; set; } = new();

        public int Count { get; set; }
    }
}
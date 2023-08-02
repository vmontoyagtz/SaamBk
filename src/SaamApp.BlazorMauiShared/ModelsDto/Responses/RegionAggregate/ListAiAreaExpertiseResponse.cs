using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class ListAiAreaExpertiseResponse : BaseResponse
    {
        public ListAiAreaExpertiseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiAreaExpertiseResponse()
        {
        }

        public List<AiAreaExpertiseDto> AiAreaExpertises { get; set; } = new();

        public int Count { get; set; }
    }
}
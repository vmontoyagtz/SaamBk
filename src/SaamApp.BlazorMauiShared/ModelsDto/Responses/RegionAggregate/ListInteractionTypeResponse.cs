using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class ListInteractionTypeResponse : BaseResponse
    {
        public ListInteractionTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListInteractionTypeResponse()
        {
        }

        public List<InteractionTypeDto> InteractionTypes { get; set; } = new();

        public int Count { get; set; }
    }
}
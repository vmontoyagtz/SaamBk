using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class CreateInteractionTypeResponse : BaseResponse
    {
        public CreateInteractionTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateInteractionTypeResponse()
        {
        }

        public InteractionTypeDto InteractionType { get; set; } = new();
    }
}
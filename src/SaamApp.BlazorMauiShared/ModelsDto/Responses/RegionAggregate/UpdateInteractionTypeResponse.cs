using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class UpdateInteractionTypeResponse : BaseResponse
    {
        public UpdateInteractionTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateInteractionTypeResponse()
        {
        }

        public InteractionTypeDto InteractionType { get; set; } = new();
    }
}
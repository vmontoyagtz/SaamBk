using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class GetByIdInteractionTypeResponse : BaseResponse
    {
        public GetByIdInteractionTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdInteractionTypeResponse()
        {
        }

        public InteractionTypeDto InteractionType { get; set; } = new();
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class UpdateInteractionTypeRequest : BaseRequest
    {
        public Guid InteractionTypeId { get; set; }
        public string InteractionTypeName { get; set; }
        public string? InteractionDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateInteractionTypeRequest FromDto(InteractionTypeDto interactionTypeDto)
        {
            return new UpdateInteractionTypeRequest
            {
                InteractionTypeId = interactionTypeDto.InteractionTypeId,
                InteractionTypeName = interactionTypeDto.InteractionTypeName,
                InteractionDescription = interactionTypeDto.InteractionDescription,
                TenantId = interactionTypeDto.TenantId
            };
        }
    }
}
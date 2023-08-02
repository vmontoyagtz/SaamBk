using System;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class CreateInteractionTypeRequest : BaseRequest
    {
        public string InteractionTypeName { get; set; }
        public string? InteractionDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}
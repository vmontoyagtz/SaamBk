using System;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class DeleteInteractionTypeRequest : BaseRequest
    {
        public Guid InteractionTypeId { get; set; }
    }
}
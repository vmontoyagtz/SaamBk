using System;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class GetByIdInteractionTypeRequest : BaseRequest
    {
        public Guid InteractionTypeId { get; set; }
    }
}
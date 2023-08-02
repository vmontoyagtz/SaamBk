using System;

namespace SaamApp.BlazorMauiShared.Models.InteractionType
{
    public class DeleteInteractionTypeResponse : BaseResponse
    {
        public DeleteInteractionTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteInteractionTypeResponse()
        {
        }
    }
}
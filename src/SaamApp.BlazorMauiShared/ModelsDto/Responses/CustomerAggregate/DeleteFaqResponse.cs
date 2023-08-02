using System;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class DeleteFaqResponse : BaseResponse
    {
        public DeleteFaqResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteFaqResponse()
        {
        }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class DeleteDiscountCodeResponse : BaseResponse
    {
        public DeleteDiscountCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteDiscountCodeResponse()
        {
        }
    }
}
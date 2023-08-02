using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class DeleteGiftCodeResponse : BaseResponse
    {
        public DeleteGiftCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteGiftCodeResponse()
        {
        }
    }
}
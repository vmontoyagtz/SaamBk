using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class DeleteAccountAdjustmentResponse : BaseResponse
    {
        public DeleteAccountAdjustmentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAccountAdjustmentResponse()
        {
        }
    }
}
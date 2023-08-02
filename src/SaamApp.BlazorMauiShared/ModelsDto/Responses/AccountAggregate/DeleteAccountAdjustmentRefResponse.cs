using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class DeleteAccountAdjustmentRefResponse : BaseResponse
    {
        public DeleteAccountAdjustmentRefResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAccountAdjustmentRefResponse()
        {
        }
    }
}
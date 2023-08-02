using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class DeleteAccountAdjustmentRefRequest : BaseRequest
    {
        public Guid AccountAdjustmentRefId { get; set; }
    }
}
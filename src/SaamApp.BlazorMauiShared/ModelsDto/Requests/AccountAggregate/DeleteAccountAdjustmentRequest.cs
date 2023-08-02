using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class DeleteAccountAdjustmentRequest : BaseRequest
    {
        public Guid AccountAdjustmentId { get; set; }
    }
}
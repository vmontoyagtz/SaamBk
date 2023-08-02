using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class GetByIdAccountAdjustmentRequest : BaseRequest
    {
        public Guid AccountAdjustmentId { get; set; }
    }
}
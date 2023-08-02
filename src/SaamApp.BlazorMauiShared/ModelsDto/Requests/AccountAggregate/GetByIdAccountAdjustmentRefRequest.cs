using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class GetByIdAccountAdjustmentRefRequest : BaseRequest
    {
        public Guid AccountAdjustmentRefId { get; set; }
    }
}
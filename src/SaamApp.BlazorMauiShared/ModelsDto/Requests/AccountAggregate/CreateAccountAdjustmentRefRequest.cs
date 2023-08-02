using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class CreateAccountAdjustmentRefRequest : BaseRequest
    {
        public string AccountAdjustmentRefName { get; set; }
        public string AccountAdjustmentRefDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}
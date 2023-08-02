using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class CreateCustomerAiHistoryRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid ModelId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public DateTime InteractionTime { get; set; }
        public Guid TenantId { get; set; }
    }
}
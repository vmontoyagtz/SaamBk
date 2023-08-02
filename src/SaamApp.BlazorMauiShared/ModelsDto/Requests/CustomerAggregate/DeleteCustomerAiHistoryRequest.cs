using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class DeleteCustomerAiHistoryRequest : BaseRequest
    {
        public Guid CustomerAiHistoryId { get; set; }
    }
}
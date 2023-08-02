using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class GetByIdCustomerAiHistoryRequest : BaseRequest
    {
        public Guid CustomerAiHistoryId { get; set; }
    }
}
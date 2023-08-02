using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class ListCustomerAiHistoryResponse : BaseResponse
    {
        public ListCustomerAiHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerAiHistoryResponse()
        {
        }

        public List<CustomerAiHistoryDto> CustomerAiHistories { get; set; } = new();

        public int Count { get; set; }
    }
}
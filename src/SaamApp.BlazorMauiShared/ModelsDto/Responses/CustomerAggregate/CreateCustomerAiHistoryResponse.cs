using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class CreateCustomerAiHistoryResponse : BaseResponse
    {
        public CreateCustomerAiHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerAiHistoryResponse()
        {
        }

        public CustomerAiHistoryDto CustomerAiHistory { get; set; } = new();
    }
}
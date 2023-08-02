using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class UpdateCustomerAiHistoryResponse : BaseResponse
    {
        public UpdateCustomerAiHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerAiHistoryResponse()
        {
        }

        public CustomerAiHistoryDto CustomerAiHistory { get; set; } = new();
    }
}
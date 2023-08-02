using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class GetByIdCustomerAiHistoryResponse : BaseResponse
    {
        public GetByIdCustomerAiHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerAiHistoryResponse()
        {
        }

        public CustomerAiHistoryDto CustomerAiHistory { get; set; } = new();
    }
}
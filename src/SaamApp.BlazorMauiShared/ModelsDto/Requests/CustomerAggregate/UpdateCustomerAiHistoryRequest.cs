using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class UpdateCustomerAiHistoryRequest : BaseRequest
    {
        public Guid CustomerAiHistoryId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ModelId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public DateTime InteractionTime { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateCustomerAiHistoryRequest FromDto(CustomerAiHistoryDto customerAiHistoryDto)
        {
            return new UpdateCustomerAiHistoryRequest
            {
                CustomerAiHistoryId = customerAiHistoryDto.CustomerAiHistoryId,
                CustomerId = customerAiHistoryDto.CustomerId,
                ModelId = customerAiHistoryDto.ModelId,
                Question = customerAiHistoryDto.Question,
                Response = customerAiHistoryDto.Response,
                InteractionTime = customerAiHistoryDto.InteractionTime,
                TenantId = customerAiHistoryDto.TenantId
            };
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerAiHistoryDto
    {
        public CustomerAiHistoryDto() { } // AutoMapper required

        public CustomerAiHistoryDto(Guid customerAiHistoryId, Guid customerId, Guid modelId, string? question,
            string? response, DateTime interactionTime, Guid tenantId)
        {
            CustomerAiHistoryId = Guard.Against.NullOrEmpty(customerAiHistoryId, nameof(customerAiHistoryId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Question = question;
            Response = response;
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid CustomerAiHistoryId { get; set; }

        [Required(ErrorMessage = "Model Id is required")]
        public Guid ModelId { get; set; }

        [MaxLength(100)] public string? Question { get; set; }

        [MaxLength(100)] public string? Response { get; set; }

        [Required(ErrorMessage = "Interaction Time is required")]
        public DateTime InteractionTime { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}
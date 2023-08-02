using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiMemoryDto
    {
        public AiMemoryDto() { } // AutoMapper required

        public AiMemoryDto(Guid aiMemoryId, Guid modelId, string? question, string? response, DateTime interactionTime,
            Guid tenantId)
        {
            AiMemoryId = Guard.Against.NullOrEmpty(aiMemoryId, nameof(aiMemoryId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Question = question;
            Response = response;
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AiMemoryId { get; set; }

        [Required(ErrorMessage = "Model Id is required")]
        public Guid ModelId { get; set; }

        [MaxLength(100)] public string? Question { get; set; }

        [MaxLength(100)] public string? Response { get; set; }

        [Required(ErrorMessage = "Interaction Time is required")]
        public DateTime InteractionTime { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }
    }
}
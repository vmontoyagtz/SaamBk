using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiErrorLogDto
    {
        public AiErrorLogDto() { } // AutoMapper required

        public AiErrorLogDto(Guid aiErrorLogId, Guid modelId, DateTime errorTime, string? errorMessage, Guid tenantId)
        {
            AiErrorLogId = Guard.Against.NullOrEmpty(aiErrorLogId, nameof(aiErrorLogId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            ErrorTime = Guard.Against.OutOfSQLDateRange(errorTime, nameof(errorTime));
            ErrorMessage = errorMessage;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AiErrorLogId { get; set; }

        [Required(ErrorMessage = "Model Id is required")]
        public Guid ModelId { get; set; }

        [Required(ErrorMessage = "Error Time is required")]
        public DateTime ErrorTime { get; set; }

        [MaxLength(100)] public string? ErrorMessage { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }
    }
}
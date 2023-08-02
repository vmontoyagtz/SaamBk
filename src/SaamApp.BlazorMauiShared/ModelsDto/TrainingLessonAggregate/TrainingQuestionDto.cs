using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TrainingQuestionDto
    {
        public TrainingQuestionDto() { } // AutoMapper required

        public TrainingQuestionDto(Guid trainingQuestionId, string? trainingQuestionValue, Guid tenantId)
        {
            TrainingQuestionId = Guard.Against.NullOrEmpty(trainingQuestionId, nameof(trainingQuestionId));
            TrainingQuestionValue = trainingQuestionValue;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid TrainingQuestionId { get; set; }

        [MaxLength(100)] public string? TrainingQuestionValue { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<TrainingQuestionOptionDto> TrainingQuestionOptions { get; set; } = new();
    }
}
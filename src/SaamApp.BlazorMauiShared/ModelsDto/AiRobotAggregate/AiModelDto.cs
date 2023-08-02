using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiModelDto
    {
        public AiModelDto() { } // AutoMapper required

        public AiModelDto(Guid aiModelId, string modelName, string? modelDescription, string? trainingData,
            DateTime trainingDate, decimal accuracy, bool isActive, Guid tenantId)
        {
            AiModelId = Guard.Against.NullOrEmpty(aiModelId, nameof(aiModelId));
            ModelName = Guard.Against.NullOrWhiteSpace(modelName, nameof(modelName));
            ModelDescription = modelDescription;
            TrainingData = trainingData;
            TrainingDate = Guard.Against.OutOfSQLDateRange(trainingDate, nameof(trainingDate));
            Accuracy = Guard.Against.Negative(accuracy, nameof(accuracy));
            IsActive = Guard.Against.Null(isActive, nameof(isActive));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AiModelId { get; set; }

        [Required(ErrorMessage = "Model Name is required")]
        [MaxLength(255)]
        public string ModelName { get; set; }

        [MaxLength(100)] public string? ModelDescription { get; set; }

        [MaxLength(100)] public string? TrainingData { get; set; }

        [Required(ErrorMessage = "Training Date is required")]
        public DateTime TrainingDate { get; set; }

        [Required(ErrorMessage = "Accuracy is required")]
        public decimal Accuracy { get; set; }

        [Required(ErrorMessage = "Is Active is required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }
    }
}
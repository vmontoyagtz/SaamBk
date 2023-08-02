using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiModel : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AiModel() { } // EF required

        //[SetsRequiredMembers]
        public AiModel(Guid aiModelId, string modelName, string? modelDescription, string? trainingData,
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

        [Key] public Guid AiModelId { get; private set; }

        public string ModelName { get; private set; }

        public string? ModelDescription { get; private set; }

        public string? TrainingData { get; private set; }

        public DateTime TrainingDate { get; private set; }

        public decimal Accuracy { get; private set; }

        public bool IsActive { get; private set; }

        public Guid TenantId { get; private set; }

        public void SetModelName(string modelName)
        {
            ModelName = Guard.Against.NullOrEmpty(modelName, nameof(modelName));
        }

        public void SetModelDescription(string modelDescription)
        {
            ModelDescription = modelDescription;
        }

        public void SetTrainingData(string trainingData)
        {
            TrainingData = trainingData;
        }
    }
}
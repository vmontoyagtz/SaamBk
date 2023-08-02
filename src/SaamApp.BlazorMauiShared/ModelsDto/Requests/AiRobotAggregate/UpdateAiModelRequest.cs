using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class UpdateAiModelRequest : BaseRequest
    {
        public Guid AiModelId { get; set; }
        public string ModelName { get; set; }
        public string? ModelDescription { get; set; }
        public string? TrainingData { get; set; }
        public DateTime TrainingDate { get; set; }
        public decimal Accuracy { get; set; }
        public bool IsActive { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAiModelRequest FromDto(AiModelDto aiModelDto)
        {
            return new UpdateAiModelRequest
            {
                AiModelId = aiModelDto.AiModelId,
                ModelName = aiModelDto.ModelName,
                ModelDescription = aiModelDto.ModelDescription,
                TrainingData = aiModelDto.TrainingData,
                TrainingDate = aiModelDto.TrainingDate,
                Accuracy = aiModelDto.Accuracy,
                IsActive = aiModelDto.IsActive,
                TenantId = aiModelDto.TenantId
            };
        }
    }
}
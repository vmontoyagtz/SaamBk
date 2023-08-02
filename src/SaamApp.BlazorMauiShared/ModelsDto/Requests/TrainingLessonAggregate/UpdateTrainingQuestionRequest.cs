using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class UpdateTrainingQuestionRequest : BaseRequest
    {
        public Guid TrainingQuestionId { get; set; }
        public string? TrainingQuestionValue { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTrainingQuestionRequest FromDto(TrainingQuestionDto trainingQuestionDto)
        {
            return new UpdateTrainingQuestionRequest
            {
                TrainingQuestionId = trainingQuestionDto.TrainingQuestionId,
                TrainingQuestionValue = trainingQuestionDto.TrainingQuestionValue,
                TenantId = trainingQuestionDto.TenantId
            };
        }
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class UpdateTrainingQuestionOptionRequest : BaseRequest
    {
        public Guid TrainingQuestionOptionId { get; set; }
        public Guid TrainingQuestionId { get; set; }
        public string TrainingQuestionOptionValue { get; set; }
        public string TrainingQuestionOptionAnswer { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTrainingQuestionOptionRequest FromDto(TrainingQuestionOptionDto trainingQuestionOptionDto)
        {
            return new UpdateTrainingQuestionOptionRequest
            {
                TrainingQuestionOptionId = trainingQuestionOptionDto.TrainingQuestionOptionId,
                TrainingQuestionId = trainingQuestionOptionDto.TrainingQuestionId,
                TrainingQuestionOptionValue = trainingQuestionOptionDto.TrainingQuestionOptionValue,
                TrainingQuestionOptionAnswer = trainingQuestionOptionDto.TrainingQuestionOptionAnswer,
                TenantId = trainingQuestionOptionDto.TenantId
            };
        }
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class CreateTrainingQuestionOptionResponse : BaseResponse
    {
        public CreateTrainingQuestionOptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTrainingQuestionOptionResponse()
        {
        }

        public TrainingQuestionOptionDto TrainingQuestionOption { get; set; } = new();
    }
}
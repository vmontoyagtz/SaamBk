using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class UpdateTrainingQuestionOptionResponse : BaseResponse
    {
        public UpdateTrainingQuestionOptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTrainingQuestionOptionResponse()
        {
        }

        public TrainingQuestionOptionDto TrainingQuestionOption { get; set; } = new();
    }
}
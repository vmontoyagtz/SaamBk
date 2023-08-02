using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class GetByIdTrainingQuestionOptionResponse : BaseResponse
    {
        public GetByIdTrainingQuestionOptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTrainingQuestionOptionResponse()
        {
        }

        public TrainingQuestionOptionDto TrainingQuestionOption { get; set; } = new();
    }
}
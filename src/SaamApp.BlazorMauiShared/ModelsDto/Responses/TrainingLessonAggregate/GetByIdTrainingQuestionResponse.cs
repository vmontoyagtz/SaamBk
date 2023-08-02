using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class GetByIdTrainingQuestionResponse : BaseResponse
    {
        public GetByIdTrainingQuestionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTrainingQuestionResponse()
        {
        }

        public TrainingQuestionDto TrainingQuestion { get; set; } = new();
    }
}
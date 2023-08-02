using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class CreateTrainingQuestionResponse : BaseResponse
    {
        public CreateTrainingQuestionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTrainingQuestionResponse()
        {
        }

        public TrainingQuestionDto TrainingQuestion { get; set; } = new();
    }
}
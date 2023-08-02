using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class UpdateTrainingQuestionResponse : BaseResponse
    {
        public UpdateTrainingQuestionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTrainingQuestionResponse()
        {
        }

        public TrainingQuestionDto TrainingQuestion { get; set; } = new();
    }
}
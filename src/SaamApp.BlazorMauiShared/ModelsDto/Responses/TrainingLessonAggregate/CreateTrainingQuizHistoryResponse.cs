using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class CreateTrainingQuizHistoryResponse : BaseResponse
    {
        public CreateTrainingQuizHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTrainingQuizHistoryResponse()
        {
        }

        public TrainingQuizHistoryDto TrainingQuizHistory { get; set; } = new();
    }
}
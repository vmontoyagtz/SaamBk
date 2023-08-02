using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class UpdateTrainingQuizHistoryResponse : BaseResponse
    {
        public UpdateTrainingQuizHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTrainingQuizHistoryResponse()
        {
        }

        public TrainingQuizHistoryDto TrainingQuizHistory { get; set; } = new();
    }
}
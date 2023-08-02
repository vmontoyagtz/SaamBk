using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class GetByIdTrainingQuizHistoryResponse : BaseResponse
    {
        public GetByIdTrainingQuizHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTrainingQuizHistoryResponse()
        {
        }

        public TrainingQuizHistoryDto TrainingQuizHistory { get; set; } = new();
    }
}
using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class ListTrainingQuizHistoryResponse : BaseResponse
    {
        public ListTrainingQuizHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTrainingQuizHistoryResponse()
        {
        }

        public List<TrainingQuizHistoryDto> TrainingQuizHistories { get; set; } = new();

        public int Count { get; set; }
    }
}
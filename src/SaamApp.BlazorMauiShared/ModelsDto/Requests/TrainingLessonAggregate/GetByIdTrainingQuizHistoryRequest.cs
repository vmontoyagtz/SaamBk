using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class GetByIdTrainingQuizHistoryRequest : BaseRequest
    {
        public Guid TrainingQuizHistoryId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class DeleteTrainingQuizHistoryRequest : BaseRequest
    {
        public Guid TrainingQuizHistoryId { get; set; }
    }
}
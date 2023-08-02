using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class CreateTrainingQuizHistoryRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public string TrainingQuizHistoryAction { get; set; }
        public int TrainingQuizHistoryStage { get; set; }
        public DateTime HistoryDate { get; set; }
    }
}
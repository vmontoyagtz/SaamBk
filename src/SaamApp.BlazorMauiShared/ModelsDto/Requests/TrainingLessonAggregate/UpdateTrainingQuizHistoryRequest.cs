using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class UpdateTrainingQuizHistoryRequest : BaseRequest
    {
        public Guid TrainingQuizHistoryId { get; set; }
        public Guid AdvisorId { get; set; }
        public string TrainingQuizHistoryAction { get; set; }
        public int TrainingQuizHistoryStage { get; set; }
        public DateTime HistoryDate { get; set; }

        public static UpdateTrainingQuizHistoryRequest FromDto(TrainingQuizHistoryDto trainingQuizHistoryDto)
        {
            return new UpdateTrainingQuizHistoryRequest
            {
                TrainingQuizHistoryId = trainingQuizHistoryDto.TrainingQuizHistoryId,
                AdvisorId = trainingQuizHistoryDto.AdvisorId,
                TrainingQuizHistoryAction = trainingQuizHistoryDto.TrainingQuizHistoryAction,
                TrainingQuizHistoryStage = trainingQuizHistoryDto.TrainingQuizHistoryStage,
                HistoryDate = trainingQuizHistoryDto.HistoryDate
            };
        }
    }
}
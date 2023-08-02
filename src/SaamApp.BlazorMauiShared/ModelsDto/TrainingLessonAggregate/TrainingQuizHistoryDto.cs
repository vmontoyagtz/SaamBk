using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TrainingQuizHistoryDto
    {
        public TrainingQuizHistoryDto() { } // AutoMapper required

        public TrainingQuizHistoryDto(Guid trainingQuizHistoryId, Guid advisorId, string trainingQuizHistoryAction,
            int trainingQuizHistoryStage, DateTime historyDate)
        {
            TrainingQuizHistoryId = Guard.Against.NullOrEmpty(trainingQuizHistoryId, nameof(trainingQuizHistoryId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            TrainingQuizHistoryAction =
                Guard.Against.NullOrWhiteSpace(trainingQuizHistoryAction, nameof(trainingQuizHistoryAction));
            TrainingQuizHistoryStage =
                Guard.Against.NegativeOrZero(trainingQuizHistoryStage, nameof(trainingQuizHistoryStage));
            HistoryDate = Guard.Against.OutOfSQLDateRange(historyDate, nameof(historyDate));
        }

        public Guid TrainingQuizHistoryId { get; set; }

        [Required(ErrorMessage = "Training Quiz History Action is required")]
        [MaxLength(100)]
        public string TrainingQuizHistoryAction { get; set; }

        [Required(ErrorMessage = "Training Quiz History Stage is required")]
        public int TrainingQuizHistoryStage { get; set; }

        [Required(ErrorMessage = "History Date is required")]
        public DateTime HistoryDate { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }
    }
}
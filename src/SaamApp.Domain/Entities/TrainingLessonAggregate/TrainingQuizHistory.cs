using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TrainingQuizHistory : BaseEntityEv<Guid>, IAggregateRoot
    {
        private TrainingQuizHistory() { } // EF required

        //[SetsRequiredMembers]
        public TrainingQuizHistory(Guid trainingQuizHistoryId, Guid advisorId, string trainingQuizHistoryAction,
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

        [Key] public Guid TrainingQuizHistoryId { get; private set; }

        public string TrainingQuizHistoryAction { get; private set; }

        public int TrainingQuizHistoryStage { get; private set; }

        public DateTime HistoryDate { get; private set; }
        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public void SetTrainingQuizHistoryAction(string trainingQuizHistoryAction)
        {
            TrainingQuizHistoryAction =
                Guard.Against.NullOrEmpty(trainingQuizHistoryAction, nameof(trainingQuizHistoryAction));
        }
    }
}
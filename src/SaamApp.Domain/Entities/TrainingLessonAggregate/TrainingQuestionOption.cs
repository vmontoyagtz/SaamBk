using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TrainingQuestionOption : BaseEntityEv<Guid>, IAggregateRoot
    {
        private TrainingQuestionOption() { } // EF required

        //[SetsRequiredMembers]
        public TrainingQuestionOption(Guid trainingQuestionOptionId, Guid trainingQuestionId,
            string trainingQuestionOptionValue, string trainingQuestionOptionAnswer, Guid tenantId)
        {
            TrainingQuestionOptionId =
                Guard.Against.NullOrEmpty(trainingQuestionOptionId, nameof(trainingQuestionOptionId));
            TrainingQuestionId = Guard.Against.NullOrEmpty(trainingQuestionId, nameof(trainingQuestionId));
            TrainingQuestionOptionValue =
                Guard.Against.NullOrWhiteSpace(trainingQuestionOptionValue, nameof(trainingQuestionOptionValue));
            TrainingQuestionOptionAnswer =
                Guard.Against.NullOrWhiteSpace(trainingQuestionOptionAnswer, nameof(trainingQuestionOptionAnswer));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid TrainingQuestionOptionId { get; private set; }

        public string TrainingQuestionOptionValue { get; private set; }

        public string TrainingQuestionOptionAnswer { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual TrainingQuestion TrainingQuestion { get; private set; }

        public Guid TrainingQuestionId { get; private set; }

        public void SetTrainingQuestionOptionValue(string trainingQuestionOptionValue)
        {
            TrainingQuestionOptionValue =
                Guard.Against.NullOrEmpty(trainingQuestionOptionValue, nameof(trainingQuestionOptionValue));
        }

        public void SetTrainingQuestionOptionAnswer(string trainingQuestionOptionAnswer)
        {
            TrainingQuestionOptionAnswer =
                Guard.Against.NullOrEmpty(trainingQuestionOptionAnswer, nameof(trainingQuestionOptionAnswer));
        }

        public void UpdateTrainingQuestionForTrainingQuestionOption(Guid newTrainingQuestionId)
        {
            Guard.Against.NullOrEmpty(newTrainingQuestionId, nameof(newTrainingQuestionId));
            if (newTrainingQuestionId == TrainingQuestionId)
            {
                return;
            }

            TrainingQuestionId = newTrainingQuestionId;
            var trainingQuestionOptionUpdatedEvent = new TrainingQuestionOptionUpdatedEvent(this, "Mongo-History");
            Events.Add(trainingQuestionOptionUpdatedEvent);
        }
    }
}
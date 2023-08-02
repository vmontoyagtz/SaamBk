using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TrainingQuestion : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<TrainingQuestionOption> _trainingQuestionOptions = new();

        private TrainingQuestion() { } // EF required

        //[SetsRequiredMembers]
        public TrainingQuestion(Guid trainingQuestionId, string? trainingQuestionValue, Guid tenantId)
        {
            TrainingQuestionId = Guard.Against.NullOrEmpty(trainingQuestionId, nameof(trainingQuestionId));
            TrainingQuestionValue = trainingQuestionValue;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid TrainingQuestionId { get; private set; }

        public string? TrainingQuestionValue { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<TrainingQuestionOption> TrainingQuestionOptions => _trainingQuestionOptions.AsReadOnly();

        public void SetTrainingQuestionValue(string trainingQuestionValue)
        {
            TrainingQuestionValue = trainingQuestionValue;
        }


        public void AddNewTrainingQuestionOption(TrainingQuestionOption trainingQuestionOption)
        {
            Guard.Against.Null(trainingQuestionOption, nameof(trainingQuestionOption));
            Guard.Against.NullOrEmpty(trainingQuestionOption.TrainingQuestionOptionId,
                nameof(trainingQuestionOption.TrainingQuestionOptionId));
            Guard.Against.DuplicateTrainingQuestionOption(_trainingQuestionOptions, trainingQuestionOption,
                nameof(trainingQuestionOption));
            _trainingQuestionOptions.Add(trainingQuestionOption);
            var trainingQuestionOptionAddedEvent =
                new TrainingQuestionOptionCreatedEvent(trainingQuestionOption, "Mongo-History");
            Events.Add(trainingQuestionOptionAddedEvent);
        }

        public void DeleteTrainingQuestionOption(TrainingQuestionOption trainingQuestionOption)
        {
            Guard.Against.Null(trainingQuestionOption, nameof(trainingQuestionOption));
            var trainingQuestionOptionToDelete = _trainingQuestionOptions
                .Where(tqo => tqo.TrainingQuestionOptionId == trainingQuestionOption.TrainingQuestionOptionId)
                .FirstOrDefault();
            if (trainingQuestionOptionToDelete != null)
            {
                _trainingQuestionOptions.Remove(trainingQuestionOptionToDelete);
                var trainingQuestionOptionDeletedEvent =
                    new TrainingQuestionOptionDeletedEvent(trainingQuestionOptionToDelete, "Mongo-History");
                Events.Add(trainingQuestionOptionDeletedEvent);
            }
        }
    }
}
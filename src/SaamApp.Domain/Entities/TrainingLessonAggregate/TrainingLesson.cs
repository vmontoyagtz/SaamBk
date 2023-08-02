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
    public class TrainingLesson : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<TrainingProgress> _trainingProgresses = new();

        private TrainingLesson() { } // EF required

        //[SetsRequiredMembers]
        public TrainingLesson(Guid trainingLessonId, string trainingLessonTitle, string trainingLessonDescription,
            string trainingLessonVimeoVideoId, string trainingLessonVideoDuration, string trainingLessonUserType,
            string? trainingLessonPreviousLesson, Guid tenantId)
        {
            TrainingLessonId = Guard.Against.NullOrEmpty(trainingLessonId, nameof(trainingLessonId));
            TrainingLessonTitle = Guard.Against.NullOrWhiteSpace(trainingLessonTitle, nameof(trainingLessonTitle));
            TrainingLessonDescription =
                Guard.Against.NullOrWhiteSpace(trainingLessonDescription, nameof(trainingLessonDescription));
            TrainingLessonVimeoVideoId =
                Guard.Against.NullOrWhiteSpace(trainingLessonVimeoVideoId, nameof(trainingLessonVimeoVideoId));
            TrainingLessonVideoDuration =
                Guard.Against.NullOrWhiteSpace(trainingLessonVideoDuration, nameof(trainingLessonVideoDuration));
            TrainingLessonUserType =
                Guard.Against.NullOrWhiteSpace(trainingLessonUserType, nameof(trainingLessonUserType));
            TrainingLessonPreviousLesson = trainingLessonPreviousLesson;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid TrainingLessonId { get; private set; }

        public string TrainingLessonTitle { get; private set; }

        public string TrainingLessonDescription { get; private set; }

        public string TrainingLessonVimeoVideoId { get; private set; }

        public string TrainingLessonVideoDuration { get; private set; }

        public string TrainingLessonUserType { get; private set; }

        public string? TrainingLessonPreviousLesson { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<TrainingProgress> TrainingProgresses => _trainingProgresses.AsReadOnly();

        public void SetTrainingLessonTitle(string trainingLessonTitle)
        {
            TrainingLessonTitle = Guard.Against.NullOrEmpty(trainingLessonTitle, nameof(trainingLessonTitle));
        }

        public void SetTrainingLessonDescription(string trainingLessonDescription)
        {
            TrainingLessonDescription =
                Guard.Against.NullOrEmpty(trainingLessonDescription, nameof(trainingLessonDescription));
        }

        public void SetTrainingLessonVimeoVideoId(string trainingLessonVimeoVideoId)
        {
            TrainingLessonVimeoVideoId =
                Guard.Against.NullOrEmpty(trainingLessonVimeoVideoId, nameof(trainingLessonVimeoVideoId));
        }

        public void SetTrainingLessonVideoDuration(string trainingLessonVideoDuration)
        {
            TrainingLessonVideoDuration =
                Guard.Against.NullOrEmpty(trainingLessonVideoDuration, nameof(trainingLessonVideoDuration));
        }

        public void SetTrainingLessonUserType(string trainingLessonUserType)
        {
            TrainingLessonUserType = Guard.Against.NullOrEmpty(trainingLessonUserType, nameof(trainingLessonUserType));
        }

        public void SetTrainingLessonPreviousLesson(string trainingLessonPreviousLesson)
        {
            TrainingLessonPreviousLesson = trainingLessonPreviousLesson;
        }


        public void AddNewTrainingProgress(TrainingProgress trainingProgress)
        {
            Guard.Against.Null(trainingProgress, nameof(trainingProgress));
            Guard.Against.NullOrEmpty(trainingProgress.TrainingProgressId, nameof(trainingProgress.TrainingProgressId));
            Guard.Against.DuplicateTrainingProgress(_trainingProgresses, trainingProgress, nameof(trainingProgress));
            _trainingProgresses.Add(trainingProgress);
            var trainingProgressAddedEvent = new TrainingProgressCreatedEvent(trainingProgress, "Mongo-History");
            Events.Add(trainingProgressAddedEvent);
        }

        public void DeleteTrainingProgress(TrainingProgress trainingProgress)
        {
            Guard.Against.Null(trainingProgress, nameof(trainingProgress));
            var trainingProgressToDelete = _trainingProgresses
                .Where(tp => tp.TrainingProgressId == trainingProgress.TrainingProgressId)
                .FirstOrDefault();
            if (trainingProgressToDelete != null)
            {
                _trainingProgresses.Remove(trainingProgressToDelete);
                var trainingProgressDeletedEvent =
                    new TrainingProgressDeletedEvent(trainingProgressToDelete, "Mongo-History");
                Events.Add(trainingProgressDeletedEvent);
            }
        }
    }
}
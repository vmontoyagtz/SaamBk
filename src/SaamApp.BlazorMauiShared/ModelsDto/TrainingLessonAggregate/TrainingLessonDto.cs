using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TrainingLessonDto
    {
        public TrainingLessonDto() { } // AutoMapper required

        public TrainingLessonDto(Guid trainingLessonId, string trainingLessonTitle, string trainingLessonDescription,
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

        public Guid TrainingLessonId { get; set; }

        [Required(ErrorMessage = "Training Lesson Title is required")]
        [MaxLength(100)]
        public string TrainingLessonTitle { get; set; }

        [Required(ErrorMessage = "Training Lesson Description is required")]
        [MaxLength(100)]
        public string TrainingLessonDescription { get; set; }

        [Required(ErrorMessage = "Training Lesson Vimeo Video Id is required")]
        [MaxLength(100)]
        public string TrainingLessonVimeoVideoId { get; set; }

        [Required(ErrorMessage = "Training Lesson Video Duration is required")]
        [MaxLength(100)]
        public string TrainingLessonVideoDuration { get; set; }

        [Required(ErrorMessage = "Training Lesson User Type is required")]
        [MaxLength(100)]
        public string TrainingLessonUserType { get; set; }

        [MaxLength(100)] public string? TrainingLessonPreviousLesson { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<TrainingProgressDto> TrainingProgresses { get; set; } = new();
    }
}
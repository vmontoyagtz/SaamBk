using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TrainingProgressDto
    {
        public TrainingProgressDto() { } // AutoMapper required

        public TrainingProgressDto(Guid trainingProgressId, Guid advisorId, Guid trainingLessonId,
            decimal trainingProgressPercentage, DateTime createdAt, Guid createdBy, DateTime? updatedAt,
            Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            TrainingProgressId = Guard.Against.NullOrEmpty(trainingProgressId, nameof(trainingProgressId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            TrainingLessonId = Guard.Against.NullOrEmpty(trainingLessonId, nameof(trainingLessonId));
            TrainingProgressPercentage =
                Guard.Against.Negative(trainingProgressPercentage, nameof(trainingProgressPercentage));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid TrainingProgressId { get; set; }

        [Required(ErrorMessage = "Training Progress Percentage is required")]
        public decimal TrainingProgressPercentage { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public TrainingLessonDto TrainingLesson { get; set; }

        [Required(ErrorMessage = "Training Lesson is required")]
        public Guid TrainingLessonId { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TrainingProgress : BaseEntityEv<Guid>, IAggregateRoot
    {
        private TrainingProgress() { } // EF required

        //[SetsRequiredMembers]
        public TrainingProgress(Guid trainingProgressId, Guid advisorId, Guid trainingLessonId,
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

        [Key] public Guid TrainingProgressId { get; private set; }

        public decimal TrainingProgressPercentage { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual TrainingLesson TrainingLesson { get; private set; }

        public Guid TrainingLessonId { get; private set; }
    }
}
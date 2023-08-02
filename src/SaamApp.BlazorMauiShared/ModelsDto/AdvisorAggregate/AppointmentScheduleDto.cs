using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AppointmentScheduleDto
    {
        public AppointmentScheduleDto() { } // AutoMapper required

        public AppointmentScheduleDto(Guid appointmentScheduleId, Guid advisorId, Guid customerId,
            DateTime scheduledTime, int duration, bool? isCancelled, string? cancellationReason, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId,
            string appointmentStatus, string? notes)
        {
            AppointmentScheduleId = Guard.Against.NullOrEmpty(appointmentScheduleId, nameof(appointmentScheduleId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            ScheduledTime = Guard.Against.OutOfSQLDateRange(scheduledTime, nameof(scheduledTime));
            Duration = Guard.Against.NegativeOrZero(duration, nameof(duration));
            IsCancelled = isCancelled;
            CancellationReason = cancellationReason;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            AppointmentStatus = Guard.Against.NullOrWhiteSpace(appointmentStatus, nameof(appointmentStatus));
            Notes = notes;
        }

        public Guid AppointmentScheduleId { get; set; }

        [Required(ErrorMessage = "Scheduled Time is required")]
        public DateTime ScheduledTime { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        public bool? IsCancelled { get; set; }

        [MaxLength(255)] public string? CancellationReason { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        [Required(ErrorMessage = "Appointment Status is required")]
        [MaxLength(50)]
        public string AppointmentStatus { get; set; }

        [MaxLength(100)] public string? Notes { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public CustomerDto Customer { get; set; }

        public Guid CustomerId { get; set; }
    }
}
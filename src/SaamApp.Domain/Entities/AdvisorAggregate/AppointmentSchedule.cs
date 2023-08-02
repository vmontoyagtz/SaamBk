using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AppointmentSchedule : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AppointmentSchedule() { } // EF required

        //[SetsRequiredMembers]
        public AppointmentSchedule(Guid appointmentScheduleId, Guid advisorId, Guid customerId, DateTime scheduledTime,
            int duration, bool? isCancelled, string? cancellationReason, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId, string appointmentStatus,
            string? notes)
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

        [Key] public Guid AppointmentScheduleId { get; private set; }

        public DateTime ScheduledTime { get; private set; }

        public int Duration { get; private set; }

        public bool? IsCancelled { get; private set; }

        public string? CancellationReason { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public string AppointmentStatus { get; private set; }

        public string? Notes { get; private set; }
        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateAdvisorForAppointmentSchedule(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var appointmentScheduleUpdatedEvent = new AppointmentScheduleUpdatedEvent(this, "Mongo-History");
            Events.Add(appointmentScheduleUpdatedEvent);
        }


        public void UpdateCustomerForAppointmentSchedule(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var appointmentScheduleUpdatedEvent = new AppointmentScheduleUpdatedEvent(this, "Mongo-History");
            Events.Add(appointmentScheduleUpdatedEvent);
        }

        public void SetCancellationReason(string cancellationReason)
        {
            CancellationReason = cancellationReason;
        }

        public void SetAppointmentStatus(string appointmentStatus)
        {
            AppointmentStatus = Guard.Against.NullOrEmpty(appointmentStatus, nameof(appointmentStatus));
        }

        public void SetNotes(string notes)
        {
            Notes = notes;
        }
    }
}
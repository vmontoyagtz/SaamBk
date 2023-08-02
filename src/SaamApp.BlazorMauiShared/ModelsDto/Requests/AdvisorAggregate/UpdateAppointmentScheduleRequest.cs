using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class UpdateAppointmentScheduleRequest : BaseRequest
    {
        public Guid AppointmentScheduleId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int Duration { get; set; }
        public bool? IsCancelled { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
        public string AppointmentStatus { get; set; }
        public string? Notes { get; set; }

        public static UpdateAppointmentScheduleRequest FromDto(AppointmentScheduleDto appointmentScheduleDto)
        {
            return new UpdateAppointmentScheduleRequest
            {
                AppointmentScheduleId = appointmentScheduleDto.AppointmentScheduleId,
                AdvisorId = appointmentScheduleDto.AdvisorId,
                CustomerId = appointmentScheduleDto.CustomerId,
                ScheduledTime = appointmentScheduleDto.ScheduledTime,
                Duration = appointmentScheduleDto.Duration,
                IsCancelled = appointmentScheduleDto.IsCancelled,
                CancellationReason = appointmentScheduleDto.CancellationReason,
                CreatedAt = appointmentScheduleDto.CreatedAt,
                CreatedBy = appointmentScheduleDto.CreatedBy,
                UpdatedAt = appointmentScheduleDto.UpdatedAt,
                UpdatedBy = appointmentScheduleDto.UpdatedBy,
                IsDeleted = appointmentScheduleDto.IsDeleted,
                TenantId = appointmentScheduleDto.TenantId,
                AppointmentStatus = appointmentScheduleDto.AppointmentStatus,
                Notes = appointmentScheduleDto.Notes
            };
        }
    }
}
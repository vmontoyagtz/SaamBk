using System;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class CreateAppointmentScheduleRequest : BaseRequest
    {
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
    }
}
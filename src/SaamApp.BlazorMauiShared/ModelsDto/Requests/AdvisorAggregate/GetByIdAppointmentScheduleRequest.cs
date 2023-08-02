using System;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class GetByIdAppointmentScheduleRequest : BaseRequest
    {
        public Guid AppointmentScheduleId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class DeleteAppointmentScheduleRequest : BaseRequest
    {
        public Guid AppointmentScheduleId { get; set; }
    }
}
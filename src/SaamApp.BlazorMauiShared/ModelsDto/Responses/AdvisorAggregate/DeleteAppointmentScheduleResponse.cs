using System;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class DeleteAppointmentScheduleResponse : BaseResponse
    {
        public DeleteAppointmentScheduleResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAppointmentScheduleResponse()
        {
        }
    }
}
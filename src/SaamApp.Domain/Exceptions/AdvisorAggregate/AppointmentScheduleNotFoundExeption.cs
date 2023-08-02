using System;

namespace SaamApp.Domain.Exceptions
{
    public class AppointmentScheduleNotFoundException : Exception
    {
        public AppointmentScheduleNotFoundException(string message) : base(message)
        {
        }

        public AppointmentScheduleNotFoundException(Guid appointmentScheduleId) : base(
            $"No appointmentSchedule with id {appointmentScheduleId} found.")
        {
        }
    }
}
using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAppointmentScheduleException : ArgumentException
    {
        public DuplicateAppointmentScheduleException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}
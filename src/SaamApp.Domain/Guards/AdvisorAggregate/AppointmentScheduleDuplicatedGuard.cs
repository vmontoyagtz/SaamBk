using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AppointmentScheduleGuardExtensions
    {
        public static void DuplicateAppointmentSchedule(this IGuardClause guardClause,
            IEnumerable<AppointmentSchedule> existingAppointmentSchedules, AppointmentSchedule newAppointmentSchedule,
            string parameterName)
        {
            if (existingAppointmentSchedules.Any(a =>
                    a.AppointmentScheduleId == newAppointmentSchedule.AppointmentScheduleId))
            {
                throw new DuplicateAppointmentScheduleException("Cannot add duplicate appointmentSchedule.",
                    parameterName);
            }
        }
    }
}
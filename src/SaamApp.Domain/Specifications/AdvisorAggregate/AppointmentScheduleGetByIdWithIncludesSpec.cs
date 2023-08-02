using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AppointmentScheduleByIdWithIncludesSpec : Specification<AppointmentSchedule>,
        ISingleResultSpecification
    {
        public AppointmentScheduleByIdWithIncludesSpec(Guid appointmentScheduleId)
        {
            Guard.Against.NullOrEmpty(appointmentScheduleId, nameof(appointmentScheduleId));
            Query.Where(appointmentSchedule => appointmentSchedule.AppointmentScheduleId == appointmentScheduleId)
                .OrderBy(appointmentSchedule => appointmentSchedule.CancellationReason)
                .Include(a => a.Advisor)
                .Include(b => b.Customer)
                .AsNoTracking();
        }
    }
}
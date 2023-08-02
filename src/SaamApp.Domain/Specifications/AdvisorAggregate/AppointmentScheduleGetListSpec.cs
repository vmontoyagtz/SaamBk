using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AppointmentScheduleGetListSpec : Specification<AppointmentSchedule>
    {
        public AppointmentScheduleGetListSpec()
        {
            Query.Where(appointmentSchedule => appointmentSchedule.IsCancelled == true)
                .OrderBy(appointmentSchedule => appointmentSchedule.CancellationReason)
                .AsNoTracking();
        }
    }
}
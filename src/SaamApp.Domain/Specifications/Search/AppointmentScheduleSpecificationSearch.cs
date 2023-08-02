using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications.Search
{
    public class AppointmentScheduleSearchByCancellationReason : Specification<AppointmentSchedule>
    {
        public AppointmentScheduleSearchByCancellationReason(AppointmentScheduleFilterModel filter)
        {
            if (!string.IsNullOrEmpty(filter.CancellationReason))
            {
                Query
                    .Search(x => x.CancellationReason, "%" + filter.CancellationReason + "%");
            }
        }
    }
}
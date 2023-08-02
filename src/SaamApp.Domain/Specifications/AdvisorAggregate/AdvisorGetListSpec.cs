using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorGetListSpec : Specification<Advisor>
    {
        public AdvisorGetListSpec()
        {
            Query.Where(advisor => advisor.IsNaturalPerson == true)
                .AsNoTracking();
        }
    }
}
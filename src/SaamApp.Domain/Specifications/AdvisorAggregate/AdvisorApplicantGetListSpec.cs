using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorApplicantGetListSpec : Specification<AdvisorApplicant>
    {
        public AdvisorApplicantGetListSpec()
        {
            Query.Where(advisorApplicant => advisorApplicant.Approved == true)
                .AsNoTracking();
        }
    }
}
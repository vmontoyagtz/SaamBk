using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorLoginGetListSpec : Specification<AdvisorLogin>
    {
        public AdvisorLoginGetListSpec()
        {
            Query.Where(advisorLogin => advisorLogin.AdvisorLoginStage == true)
                .AsNoTracking();
        }
    }
}
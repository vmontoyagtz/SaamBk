using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorBankGetListSpec : Specification<AdvisorBank>
    {
        public AdvisorBankGetListSpec()
        {
            Query.Where(advisorBank => advisorBank.IsDefault == true)
                .AsNoTracking();
        }
    }
}
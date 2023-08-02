using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorPhoneNumberGetListSpec : Specification<AdvisorPhoneNumber>
    {
        public AdvisorPhoneNumberGetListSpec()
        {
            Query.OrderBy(advisorPhoneNumber => advisorPhoneNumber.RowId)
                .AsNoTracking();
        }
    }
}
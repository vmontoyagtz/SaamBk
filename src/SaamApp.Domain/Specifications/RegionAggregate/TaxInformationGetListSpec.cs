using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TaxInformationGetListSpec : Specification<TaxInformation>
    {
        public TaxInformationGetListSpec()
        {
            Query.Where(taxInformation => taxInformation.IsDeleted == false)
                .AsNoTracking();
        }
    }
}
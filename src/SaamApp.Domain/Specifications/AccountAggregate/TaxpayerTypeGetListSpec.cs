using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TaxpayerTypeGetListSpec : Specification<TaxpayerType>
    {
        public TaxpayerTypeGetListSpec()
        {
            Query.OrderBy(taxpayerType => taxpayerType.TaxpayerTypeId)
                .AsNoTracking();
        }
    }
}
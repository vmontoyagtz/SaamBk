using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AddressTypeGetListSpec : Specification<AddressType>
    {
        public AddressTypeGetListSpec()
        {
            Query.OrderBy(addressType => addressType.AddressTypeId)
                .AsNoTracking();
        }
    }
}
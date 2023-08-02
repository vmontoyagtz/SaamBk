using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AddressGetListSpec : Specification<Address>
    {
        public AddressGetListSpec()
        {
            Query.OrderBy(address => address.AddressId)
                .AsNoTracking();
        }
    }
}
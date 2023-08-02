using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PhoneNumberGetListSpec : Specification<PhoneNumber>
    {
        public PhoneNumberGetListSpec()
        {
            Query.OrderBy(phoneNumber => phoneNumber.PhoneNumberId)
                .AsNoTracking();
        }
    }
}
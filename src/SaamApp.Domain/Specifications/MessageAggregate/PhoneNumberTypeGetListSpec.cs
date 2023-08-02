using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PhoneNumberTypeGetListSpec : Specification<PhoneNumberType>
    {
        public PhoneNumberTypeGetListSpec()
        {
            Query.OrderBy(phoneNumberType => phoneNumberType.PhoneNumberTypeId)
                .AsNoTracking();
        }
    }
}
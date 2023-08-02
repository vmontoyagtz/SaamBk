using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmailAddressTypeGetListSpec : Specification<EmailAddressType>
    {
        public EmailAddressTypeGetListSpec()
        {
            Query.OrderBy(emailAddressType => emailAddressType.EmailAddressTypeId)
                .AsNoTracking();
        }
    }
}
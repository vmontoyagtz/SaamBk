using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmailAddressGetListSpec : Specification<EmailAddress>
    {
        public EmailAddressGetListSpec()
        {
            Query.OrderBy(emailAddress => emailAddress.EmailAddressId)
                .AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorEmailAddressWithEmailAddressKeySpec : Specification<AdvisorEmailAddress>
    {
        public GetAdvisorEmailAddressWithEmailAddressKeySpec(Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Query.Where(aea => aea.EmailAddressId == emailAddressId).AsNoTracking();
        }
    }

    public class GetBusinessUnitEmailAddressWithEmailAddressKeySpec : Specification<BusinessUnitEmailAddress>
    {
        public GetBusinessUnitEmailAddressWithEmailAddressKeySpec(Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Query.Where(buea => buea.EmailAddressId == emailAddressId).AsNoTracking();
        }
    }

    public class GetCustomerEmailAddressWithEmailAddressKeySpec : Specification<CustomerEmailAddress>
    {
        public GetCustomerEmailAddressWithEmailAddressKeySpec(Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Query.Where(cea => cea.EmailAddressId == emailAddressId).AsNoTracking();
        }
    }

    public class GetEmployeeEmailAddressWithEmailAddressKeySpec : Specification<EmployeeEmailAddress>
    {
        public GetEmployeeEmailAddressWithEmailAddressKeySpec(Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Query.Where(eea => eea.EmailAddressId == emailAddressId).AsNoTracking();
        }
    }
}
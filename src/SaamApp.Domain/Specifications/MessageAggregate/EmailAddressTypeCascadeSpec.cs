using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorEmailAddressWithEmailAddressTypeKeySpec : Specification<AdvisorEmailAddress>
    {
        public GetAdvisorEmailAddressWithEmailAddressTypeKeySpec(Guid emailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            Query.Where(aea => aea.EmailAddressTypeId == emailAddressTypeId).AsNoTracking();
        }
    }

    public class GetBusinessUnitEmailAddressWithEmailAddressTypeKeySpec : Specification<BusinessUnitEmailAddress>
    {
        public GetBusinessUnitEmailAddressWithEmailAddressTypeKeySpec(Guid emailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            Query.Where(buea => buea.EmailAddressTypeId == emailAddressTypeId).AsNoTracking();
        }
    }

    public class GetCustomerEmailAddressWithEmailAddressTypeKeySpec : Specification<CustomerEmailAddress>
    {
        public GetCustomerEmailAddressWithEmailAddressTypeKeySpec(Guid emailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            Query.Where(cea => cea.EmailAddressTypeId == emailAddressTypeId).AsNoTracking();
        }
    }

    public class GetEmployeeEmailAddressWithEmailAddressTypeKeySpec : Specification<EmployeeEmailAddress>
    {
        public GetEmployeeEmailAddressWithEmailAddressTypeKeySpec(Guid emailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            Query.Where(eea => eea.EmailAddressTypeId == emailAddressTypeId).AsNoTracking();
        }
    }
}
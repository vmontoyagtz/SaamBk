using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorPhoneNumberWithPhoneNumberKeySpec : Specification<AdvisorPhoneNumber>
    {
        public GetAdvisorPhoneNumberWithPhoneNumberKeySpec(Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(apn => apn.PhoneNumberId == phoneNumberId).AsNoTracking();
        }
    }

    public class GetBusinessUnitPhoneNumberWithPhoneNumberKeySpec : Specification<BusinessUnitPhoneNumber>
    {
        public GetBusinessUnitPhoneNumberWithPhoneNumberKeySpec(Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(bupn => bupn.PhoneNumberId == phoneNumberId).AsNoTracking();
        }
    }

    public class GetCustomerPhoneNumberWithPhoneNumberKeySpec : Specification<CustomerPhoneNumber>
    {
        public GetCustomerPhoneNumberWithPhoneNumberKeySpec(Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(cpn => cpn.PhoneNumberId == phoneNumberId).AsNoTracking();
        }
    }

    public class GetEmployeePhoneNumberWithPhoneNumberKeySpec : Specification<EmployeePhoneNumber>
    {
        public GetEmployeePhoneNumberWithPhoneNumberKeySpec(Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(epn => epn.PhoneNumberId == phoneNumberId).AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorPhoneNumberWithPhoneNumberTypeKeySpec : Specification<AdvisorPhoneNumber>
    {
        public GetAdvisorPhoneNumberWithPhoneNumberTypeKeySpec(Guid phoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
            Query.Where(apn => apn.PhoneNumberTypeId == phoneNumberTypeId).AsNoTracking();
        }
    }

    public class GetBusinessUnitPhoneNumberWithPhoneNumberTypeKeySpec : Specification<BusinessUnitPhoneNumber>
    {
        public GetBusinessUnitPhoneNumberWithPhoneNumberTypeKeySpec(Guid phoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
            Query.Where(bupn => bupn.PhoneNumberTypeId == phoneNumberTypeId).AsNoTracking();
        }
    }

    public class GetCustomerPhoneNumberWithPhoneNumberTypeKeySpec : Specification<CustomerPhoneNumber>
    {
        public GetCustomerPhoneNumberWithPhoneNumberTypeKeySpec(Guid phoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
            Query.Where(cpn => cpn.PhoneNumberTypeId == phoneNumberTypeId).AsNoTracking();
        }
    }

    public class GetEmployeePhoneNumberWithPhoneNumberTypeKeySpec : Specification<EmployeePhoneNumber>
    {
        public GetEmployeePhoneNumberWithPhoneNumberTypeKeySpec(Guid phoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
            Query.Where(epn => epn.PhoneNumberTypeId == phoneNumberTypeId).AsNoTracking();
        }
    }
}
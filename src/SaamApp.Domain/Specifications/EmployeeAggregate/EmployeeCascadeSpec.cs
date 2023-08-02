using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetEmployeeAddressWithEmployeeKeySpec : Specification<EmployeeAddress>
    {
        public GetEmployeeAddressWithEmployeeKeySpec(Guid employeeId)
        {
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Query.Where(ea => ea.EmployeeId == employeeId).AsNoTracking();
        }
    }

    public class GetEmployeeEmailAddressWithEmployeeKeySpec : Specification<EmployeeEmailAddress>
    {
        public GetEmployeeEmailAddressWithEmployeeKeySpec(Guid employeeId)
        {
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Query.Where(eea => eea.EmployeeId == employeeId).AsNoTracking();
        }
    }

    public class GetEmployeePhoneNumberWithEmployeeKeySpec : Specification<EmployeePhoneNumber>
    {
        public GetEmployeePhoneNumberWithEmployeeKeySpec(Guid employeeId)
        {
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Query.Where(epn => epn.EmployeeId == employeeId).AsNoTracking();
        }
    }
}
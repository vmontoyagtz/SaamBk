using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeeEmailAddressByRelIdsSpec : Specification<EmployeeEmailAddress>
    {
        public EmployeeEmailAddressByRelIdsSpec(Guid emailAddressId, Guid employeeId)
        {
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Query.Where(employeeEmailAddress => employeeEmailAddress.EmailAddressId == emailAddressId &&
                                                employeeEmailAddress.EmployeeId == employeeId).AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeePhoneNumberByRelIdsSpec : Specification<EmployeePhoneNumber>
    {
        public EmployeePhoneNumberByRelIdsSpec(Guid employeeId, Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(employeePhoneNumber => employeePhoneNumber.EmployeeId == employeeId &&
                                               employeePhoneNumber.PhoneNumberId == phoneNumberId).AsNoTracking();
        }
    }
}
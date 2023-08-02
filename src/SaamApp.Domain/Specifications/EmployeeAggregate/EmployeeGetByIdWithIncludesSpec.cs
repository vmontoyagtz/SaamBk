using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeeByIdWithIncludesSpec : Specification<Employee>, ISingleResultSpecification
    {
        public EmployeeByIdWithIncludesSpec(Guid employeeId)
        {
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Query.Where(employee => employee.EmployeeId == employeeId)
                .Include(a => a.EmployeeAddresses)
                .ThenInclude(b => b.Address).Include(b => b.EmployeeAddresses).ThenInclude(b => b.AddressType)
                .Include(b => b.EmployeeEmailAddresses)
                .ThenInclude(c => c.EmailAddress).Include(c => c.EmployeeEmailAddresses)
                .ThenInclude(c => c.EmailAddressType)
                .Include(c => c.EmployeePhoneNumbers)
                .ThenInclude(d => d.PhoneNumber).Include(d => d.EmployeePhoneNumbers)
                .ThenInclude(d => d.PhoneNumberType)
                .AsNoTracking();
        }
    }
}
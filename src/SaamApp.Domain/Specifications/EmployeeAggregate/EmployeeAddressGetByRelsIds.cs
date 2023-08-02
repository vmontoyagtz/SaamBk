using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeeAddressByRelIdsSpec : Specification<EmployeeAddress>
    {
        public EmployeeAddressByRelIdsSpec(Guid addressId, Guid employeeId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Query.Where(employeeAddress =>
                employeeAddress.AddressId == addressId && employeeAddress.EmployeeId == employeeId).AsNoTracking();
        }
    }
}
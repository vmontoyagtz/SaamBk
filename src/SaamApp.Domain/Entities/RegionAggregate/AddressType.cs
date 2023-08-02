using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AddressType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorAddress> _advisorAddresses = new();

        private readonly List<BusinessUnitAddress> _businessUnitAddresses = new();

        private readonly List<CustomerAddress> _customerAddresses = new();

        private readonly List<EmployeeAddress> _employeeAddresses = new();


        private AddressType() { } // EF required

        //[SetsRequiredMembers]
        public AddressType(Guid addressTypeId, string addressTypeName, string? description, Guid tenantId)
        {
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            AddressTypeName = Guard.Against.NullOrWhiteSpace(addressTypeName, nameof(addressTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AddressTypeId { get; private set; }

        public string AddressTypeName { get; private set; }

        public string? Description { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AdvisorAddress> AdvisorAddresses => _advisorAddresses.AsReadOnly();
        public IEnumerable<BusinessUnitAddress> BusinessUnitAddresses => _businessUnitAddresses.AsReadOnly();
        public IEnumerable<CustomerAddress> CustomerAddresses => _customerAddresses.AsReadOnly();
        public IEnumerable<EmployeeAddress> EmployeeAddresses => _employeeAddresses.AsReadOnly();

        public void SetAddressTypeName(string addressTypeName)
        {
            AddressTypeName = Guard.Against.NullOrEmpty(addressTypeName, nameof(addressTypeName));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
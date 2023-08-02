using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Address : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorAddress> _advisorAddresses = new();

        private readonly List<BusinessUnitAddress> _businessUnitAddresses = new();

        private readonly List<CustomerAddress> _customerAddresses = new();

        private readonly List<EmployeeAddress> _employeeAddresses = new();


        private Address() { } // EF required

        //[SetsRequiredMembers]
        public Address(Guid addressId, Guid cityId, Guid countryId, Guid regionId, Guid stateId, string addressStr,
            string zipCode, Guid tenantId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            CityId = Guard.Against.NullOrEmpty(cityId, nameof(cityId));
            CountryId = Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            StateId = Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            AddressStr = Guard.Against.NullOrWhiteSpace(addressStr, nameof(addressStr));
            ZipCode = Guard.Against.NullOrWhiteSpace(zipCode, nameof(zipCode));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AddressId { get; private set; }

        public string AddressStr { get; private set; }

        public string ZipCode { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual City City { get; private set; }

        public Guid CityId { get; private set; }

        public virtual Country Country { get; private set; }

        public Guid CountryId { get; private set; }

        public virtual Region Region { get; private set; }

        public Guid RegionId { get; private set; }

        public virtual State State { get; private set; }

        public Guid StateId { get; private set; }
        public IEnumerable<AdvisorAddress> AdvisorAddresses => _advisorAddresses.AsReadOnly();
        public IEnumerable<BusinessUnitAddress> BusinessUnitAddresses => _businessUnitAddresses.AsReadOnly();
        public IEnumerable<CustomerAddress> CustomerAddresses => _customerAddresses.AsReadOnly();
        public IEnumerable<EmployeeAddress> EmployeeAddresses => _employeeAddresses.AsReadOnly();

        public void SetAddressStr(string addressStr)
        {
            AddressStr = Guard.Against.NullOrEmpty(addressStr, nameof(addressStr));
        }

        public void SetZipCode(string zipCode)
        {
            ZipCode = Guard.Against.NullOrEmpty(zipCode, nameof(zipCode));
        }
    }
}
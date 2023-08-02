using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class PhoneNumberType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorPhoneNumber> _advisorPhoneNumbers = new();

        private readonly List<BusinessUnitPhoneNumber> _businessUnitPhoneNumbers = new();

        private readonly List<CustomerPhoneNumber> _customerPhoneNumbers = new();

        private readonly List<EmployeePhoneNumber> _employeePhoneNumbers = new();


        private PhoneNumberType() { } // EF required

        //[SetsRequiredMembers]
        public PhoneNumberType(Guid phoneNumberTypeId, string phoneNumberTypeName, string? description, Guid tenantId)
        {
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
            PhoneNumberTypeName = Guard.Against.NullOrWhiteSpace(phoneNumberTypeName, nameof(phoneNumberTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid PhoneNumberTypeId { get; private set; }

        public string PhoneNumberTypeName { get; private set; }

        public string? Description { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AdvisorPhoneNumber> AdvisorPhoneNumbers => _advisorPhoneNumbers.AsReadOnly();
        public IEnumerable<BusinessUnitPhoneNumber> BusinessUnitPhoneNumbers => _businessUnitPhoneNumbers.AsReadOnly();
        public IEnumerable<CustomerPhoneNumber> CustomerPhoneNumbers => _customerPhoneNumbers.AsReadOnly();
        public IEnumerable<EmployeePhoneNumber> EmployeePhoneNumbers => _employeePhoneNumbers.AsReadOnly();

        public void SetPhoneNumberTypeName(string phoneNumberTypeName)
        {
            PhoneNumberTypeName = Guard.Against.NullOrEmpty(phoneNumberTypeName, nameof(phoneNumberTypeName));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
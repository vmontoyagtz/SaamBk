using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class EmailAddressType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorEmailAddress> _advisorEmailAddresses = new();

        private readonly List<BusinessUnitEmailAddress> _businessUnitEmailAddresses = new();

        private readonly List<CustomerEmailAddress> _customerEmailAddresses = new();

        private readonly List<EmployeeEmailAddress> _employeeEmailAddresses = new();


        private EmailAddressType() { } // EF required

        //[SetsRequiredMembers]
        public EmailAddressType(Guid emailAddressTypeId, string emailAddressTypeName, string? description,
            Guid tenantId)
        {
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            EmailAddressTypeName = Guard.Against.NullOrWhiteSpace(emailAddressTypeName, nameof(emailAddressTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid EmailAddressTypeId { get; private set; }

        public string EmailAddressTypeName { get; private set; }

        public string? Description { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AdvisorEmailAddress> AdvisorEmailAddresses => _advisorEmailAddresses.AsReadOnly();

        public IEnumerable<BusinessUnitEmailAddress> BusinessUnitEmailAddresses =>
            _businessUnitEmailAddresses.AsReadOnly();

        public IEnumerable<CustomerEmailAddress> CustomerEmailAddresses => _customerEmailAddresses.AsReadOnly();
        public IEnumerable<EmployeeEmailAddress> EmployeeEmailAddresses => _employeeEmailAddresses.AsReadOnly();

        public void SetEmailAddressTypeName(string emailAddressTypeName)
        {
            EmailAddressTypeName = Guard.Against.NullOrEmpty(emailAddressTypeName, nameof(emailAddressTypeName));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
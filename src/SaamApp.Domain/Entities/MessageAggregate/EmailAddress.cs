using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class EmailAddress : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorEmailAddress> _advisorEmailAddresses = new();

        private readonly List<BusinessUnitEmailAddress> _businessUnitEmailAddresses = new();

        private readonly List<CustomerEmailAddress> _customerEmailAddresses = new();

        private readonly List<EmployeeEmailAddress> _employeeEmailAddresses = new();


        private EmailAddress() { } // EF required

        //[SetsRequiredMembers]
        public EmailAddress(Guid emailAddressId, string emailAddressString)
        {
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressString = Guard.Against.NullOrWhiteSpace(emailAddressString, nameof(emailAddressString));
        }

        [Key] public Guid EmailAddressId { get; private set; }

        public string EmailAddressString { get; private set; }
        public IEnumerable<AdvisorEmailAddress> AdvisorEmailAddresses => _advisorEmailAddresses.AsReadOnly();

        public IEnumerable<BusinessUnitEmailAddress> BusinessUnitEmailAddresses =>
            _businessUnitEmailAddresses.AsReadOnly();

        public IEnumerable<CustomerEmailAddress> CustomerEmailAddresses => _customerEmailAddresses.AsReadOnly();
        public IEnumerable<EmployeeEmailAddress> EmployeeEmailAddresses => _employeeEmailAddresses.AsReadOnly();

        public void SetEmailAddressString(string emailAddressString)
        {
            EmailAddressString = Guard.Against.NullOrEmpty(emailAddressString, nameof(emailAddressString));
        }
    }
}
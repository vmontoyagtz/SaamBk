using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class PhoneNumber : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorPhoneNumber> _advisorPhoneNumbers = new();

        private readonly List<BusinessUnitPhoneNumber> _businessUnitPhoneNumbers = new();

        private readonly List<CustomerPhoneNumber> _customerPhoneNumbers = new();

        private readonly List<EmployeePhoneNumber> _employeePhoneNumbers = new();


        private PhoneNumber() { } // EF required

        //[SetsRequiredMembers]
        public PhoneNumber(Guid phoneNumberId, string phoneNumberString)
        {
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberString = Guard.Against.NullOrWhiteSpace(phoneNumberString, nameof(phoneNumberString));
        }

        [Key] public Guid PhoneNumberId { get; private set; }

        public string PhoneNumberString { get; private set; }
        public IEnumerable<AdvisorPhoneNumber> AdvisorPhoneNumbers => _advisorPhoneNumbers.AsReadOnly();
        public IEnumerable<BusinessUnitPhoneNumber> BusinessUnitPhoneNumbers => _businessUnitPhoneNumbers.AsReadOnly();
        public IEnumerable<CustomerPhoneNumber> CustomerPhoneNumbers => _customerPhoneNumbers.AsReadOnly();
        public IEnumerable<EmployeePhoneNumber> EmployeePhoneNumbers => _employeePhoneNumbers.AsReadOnly();

        public void SetPhoneNumberString(string phoneNumberString)
        {
            PhoneNumberString = Guard.Against.NullOrEmpty(phoneNumberString, nameof(phoneNumberString));
        }
    }
}
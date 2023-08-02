using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Employee : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<EmployeeAddress> _employeeAddresses = new();

        private readonly List<EmployeeEmailAddress> _employeeEmailAddresses = new();

        private readonly List<EmployeePhoneNumber> _employeePhoneNumbers = new();

        private Employee() { } // EF required

        //[SetsRequiredMembers]
        public Employee(Guid employeeId, string employeeFirstName, string employeeLastName, string? employeeNumber,
            string? employeeJobTitle, DateTime? employeeHireDate, bool? isActive, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            EmployeeFirstName = Guard.Against.NullOrWhiteSpace(employeeFirstName, nameof(employeeFirstName));
            EmployeeLastName = Guard.Against.NullOrWhiteSpace(employeeLastName, nameof(employeeLastName));
            EmployeeNumber = employeeNumber;
            EmployeeJobTitle = employeeJobTitle;
            EmployeeHireDate = employeeHireDate;
            IsActive = isActive;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid EmployeeId { get; private set; }

        public string EmployeeFirstName { get; private set; }

        public string EmployeeLastName { get; private set; }

        public string? EmployeeNumber { get; private set; }

        public string? EmployeeJobTitle { get; private set; }

        public DateTime? EmployeeHireDate { get; private set; }

        public bool? IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<EmployeeAddress> EmployeeAddresses => _employeeAddresses.AsReadOnly();
        public IEnumerable<EmployeeEmailAddress> EmployeeEmailAddresses => _employeeEmailAddresses.AsReadOnly();
        public IEnumerable<EmployeePhoneNumber> EmployeePhoneNumbers => _employeePhoneNumbers.AsReadOnly();

        public void SetEmployeeFirstName(string employeeFirstName)
        {
            EmployeeFirstName = Guard.Against.NullOrEmpty(employeeFirstName, nameof(employeeFirstName));
        }

        public void SetEmployeeLastName(string employeeLastName)
        {
            EmployeeLastName = Guard.Against.NullOrEmpty(employeeLastName, nameof(employeeLastName));
        }

        public void SetEmployeeNumber(string employeeNumber)
        {
            EmployeeNumber = employeeNumber;
        }

        public void SetEmployeeJobTitle(string employeeJobTitle)
        {
            EmployeeJobTitle = employeeJobTitle;
        }


        public void AddNewEmployeeAddress(Guid addressId, Guid addressTypeId, Guid employeeId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));

            var newEmployeeAddress = new EmployeeAddress(addressId, addressTypeId, employeeId);
            Guard.Against.DuplicateEmployeeAddress(_employeeAddresses, newEmployeeAddress, nameof(newEmployeeAddress));
            _employeeAddresses.Add(newEmployeeAddress);
            var employeeAddressAddedEvent = new EmployeeAddressCreatedEvent(newEmployeeAddress, "Mongo-History");
            Events.Add(employeeAddressAddedEvent);
        }

        public void DeleteEmployeeAddress(Guid addressId, Guid employeeId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));

            var employeeAddressToDelete = _employeeAddresses
                .Where(ea1 => ea1.AddressId == addressId)
                .Where(ea3 => ea3.EmployeeId == employeeId)
                .FirstOrDefault();

            if (employeeAddressToDelete != null)
            {
                _employeeAddresses.Remove(employeeAddressToDelete);
                var employeeAddressDeletedEvent =
                    new EmployeeAddressDeletedEvent(employeeAddressToDelete, "Mongo-History");
                Events.Add(employeeAddressDeletedEvent);
            }
        }

        public void AddNewEmployeeEmailAddress(Guid emailAddressId, Guid emailAddressTypeId, Guid employeeId)
        {
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));

            var newEmployeeEmailAddress = new EmployeeEmailAddress(emailAddressId, emailAddressTypeId, employeeId);
            Guard.Against.DuplicateEmployeeEmailAddress(_employeeEmailAddresses, newEmployeeEmailAddress,
                nameof(newEmployeeEmailAddress));
            _employeeEmailAddresses.Add(newEmployeeEmailAddress);
            var employeeEmailAddressAddedEvent =
                new EmployeeEmailAddressCreatedEvent(newEmployeeEmailAddress, "Mongo-History");
            Events.Add(employeeEmailAddressAddedEvent);
        }

        public void DeleteEmployeeEmailAddress(Guid emailAddressId, Guid employeeId)
        {
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));

            var employeeEmailAddressToDelete = _employeeEmailAddresses
                .Where(eea1 => eea1.EmailAddressId == emailAddressId)
                .Where(eea3 => eea3.EmployeeId == employeeId)
                .FirstOrDefault();

            if (employeeEmailAddressToDelete != null)
            {
                _employeeEmailAddresses.Remove(employeeEmailAddressToDelete);
                var employeeEmailAddressDeletedEvent =
                    new EmployeeEmailAddressDeletedEvent(employeeEmailAddressToDelete, "Mongo-History");
                Events.Add(employeeEmailAddressDeletedEvent);
            }
        }

        public void AddNewEmployeePhoneNumber(Guid employeeId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));

            var newEmployeePhoneNumber = new EmployeePhoneNumber(employeeId, phoneNumberId, phoneNumberTypeId);
            Guard.Against.DuplicateEmployeePhoneNumber(_employeePhoneNumbers, newEmployeePhoneNumber,
                nameof(newEmployeePhoneNumber));
            _employeePhoneNumbers.Add(newEmployeePhoneNumber);
            var employeePhoneNumberAddedEvent =
                new EmployeePhoneNumberCreatedEvent(newEmployeePhoneNumber, "Mongo-History");
            Events.Add(employeePhoneNumberAddedEvent);
        }

        public void DeleteEmployeePhoneNumber(Guid employeeId, Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));

            var employeePhoneNumberToDelete = _employeePhoneNumbers
                .Where(epn1 => epn1.EmployeeId == employeeId)
                .Where(epn2 => epn2.PhoneNumberId == phoneNumberId)
                .FirstOrDefault();

            if (employeePhoneNumberToDelete != null)
            {
                _employeePhoneNumbers.Remove(employeePhoneNumberToDelete);
                var employeePhoneNumberDeletedEvent =
                    new EmployeePhoneNumberDeletedEvent(employeePhoneNumberToDelete, "Mongo-History");
                Events.Add(employeePhoneNumberDeletedEvent);
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class EmployeePhoneNumber : BaseEntityEv<int>, IAggregateRoot
    {
        private EmployeePhoneNumber() { } // EF required

        //[SetsRequiredMembers]
        public EmployeePhoneNumber(Guid employeeId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Employee Employee { get; private set; }

        public Guid EmployeeId { get; private set; }

        public virtual PhoneNumber PhoneNumber { get; private set; }

        public Guid PhoneNumberId { get; private set; }

        public virtual PhoneNumberType PhoneNumberType { get; private set; }

        public Guid PhoneNumberTypeId { get; private set; }


        public void UpdateEmployeeForEmployeePhoneNumber(Guid newEmployeeId)
        {
            Guard.Against.NullOrEmpty(newEmployeeId, nameof(newEmployeeId));
            if (newEmployeeId == EmployeeId)
            {
                return;
            }

            EmployeeId = newEmployeeId;
            var employeePhoneNumberUpdatedEvent = new EmployeePhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(employeePhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberForEmployeePhoneNumber(Guid newPhoneNumberId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberId, nameof(newPhoneNumberId));
            if (newPhoneNumberId == PhoneNumberId)
            {
                return;
            }

            PhoneNumberId = newPhoneNumberId;
            var employeePhoneNumberUpdatedEvent = new EmployeePhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(employeePhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberTypeForEmployeePhoneNumber(Guid newPhoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberTypeId, nameof(newPhoneNumberTypeId));
            if (newPhoneNumberTypeId == PhoneNumberTypeId)
            {
                return;
            }

            PhoneNumberTypeId = newPhoneNumberTypeId;
            var employeePhoneNumberUpdatedEvent = new EmployeePhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(employeePhoneNumberUpdatedEvent);
        }
    }
}
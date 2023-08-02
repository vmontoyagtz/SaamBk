using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class EmployeeAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private EmployeeAddress() { } // EF required

        //[SetsRequiredMembers]
        public EmployeeAddress(Guid addressId, Guid addressTypeId, Guid employeeId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Address Address { get; private set; }

        public Guid AddressId { get; private set; }

        public virtual AddressType AddressType { get; private set; }

        public Guid AddressTypeId { get; private set; }

        public virtual Employee Employee { get; private set; }

        public Guid EmployeeId { get; private set; }


        public void UpdateAddressForEmployeeAddress(Guid newAddressId)
        {
            Guard.Against.NullOrEmpty(newAddressId, nameof(newAddressId));
            if (newAddressId == AddressId)
            {
                return;
            }

            AddressId = newAddressId;
            var employeeAddressUpdatedEvent = new EmployeeAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(employeeAddressUpdatedEvent);
        }


        public void UpdateAddressTypeForEmployeeAddress(Guid newAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newAddressTypeId, nameof(newAddressTypeId));
            if (newAddressTypeId == AddressTypeId)
            {
                return;
            }

            AddressTypeId = newAddressTypeId;
            var employeeAddressUpdatedEvent = new EmployeeAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(employeeAddressUpdatedEvent);
        }


        public void UpdateEmployeeForEmployeeAddress(Guid newEmployeeId)
        {
            Guard.Against.NullOrEmpty(newEmployeeId, nameof(newEmployeeId));
            if (newEmployeeId == EmployeeId)
            {
                return;
            }

            EmployeeId = newEmployeeId;
            var employeeAddressUpdatedEvent = new EmployeeAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(employeeAddressUpdatedEvent);
        }
    }
}
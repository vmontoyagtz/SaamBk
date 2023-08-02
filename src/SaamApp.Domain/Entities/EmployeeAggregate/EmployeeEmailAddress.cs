using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class EmployeeEmailAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private EmployeeEmailAddress() { } // EF required

        //[SetsRequiredMembers]
        public EmployeeEmailAddress(Guid emailAddressId, Guid emailAddressTypeId, Guid employeeId)
        {
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual EmailAddress EmailAddress { get; private set; }

        public Guid EmailAddressId { get; private set; }

        public virtual EmailAddressType EmailAddressType { get; private set; }

        public Guid EmailAddressTypeId { get; private set; }

        public virtual Employee Employee { get; private set; }

        public Guid EmployeeId { get; private set; }


        public void UpdateEmailAddressForEmployeeEmailAddress(Guid newEmailAddressId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressId, nameof(newEmailAddressId));
            if (newEmailAddressId == EmailAddressId)
            {
                return;
            }

            EmailAddressId = newEmailAddressId;
            var employeeEmailAddressUpdatedEvent = new EmployeeEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(employeeEmailAddressUpdatedEvent);
        }


        public void UpdateEmailAddressTypeForEmployeeEmailAddress(Guid newEmailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressTypeId, nameof(newEmailAddressTypeId));
            if (newEmailAddressTypeId == EmailAddressTypeId)
            {
                return;
            }

            EmailAddressTypeId = newEmailAddressTypeId;
            var employeeEmailAddressUpdatedEvent = new EmployeeEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(employeeEmailAddressUpdatedEvent);
        }


        public void UpdateEmployeeForEmployeeEmailAddress(Guid newEmployeeId)
        {
            Guard.Against.NullOrEmpty(newEmployeeId, nameof(newEmployeeId));
            if (newEmployeeId == EmployeeId)
            {
                return;
            }

            EmployeeId = newEmployeeId;
            var employeeEmailAddressUpdatedEvent = new EmployeeEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(employeeEmailAddressUpdatedEvent);
        }
    }
}
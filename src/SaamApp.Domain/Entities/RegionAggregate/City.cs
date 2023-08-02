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
    public class City : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Address> _addresses = new();

        private City() { } // EF required

        //[SetsRequiredMembers]
        public City(Guid cityId, Guid stateId, string cityName, Guid tenantId)
        {
            CityId = Guard.Against.NullOrEmpty(cityId, nameof(cityId));
            StateId = Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            CityName = Guard.Against.NullOrWhiteSpace(cityName, nameof(cityName));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid CityId { get; private set; }

        public string CityName { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual State State { get; private set; }

        public Guid StateId { get; private set; }
        public IEnumerable<Address> Addresses => _addresses.AsReadOnly();

        public void SetCityName(string cityName)
        {
            CityName = Guard.Against.NullOrEmpty(cityName, nameof(cityName));
        }

        public void UpdateStateForCity(Guid newStateId)
        {
            Guard.Against.NullOrEmpty(newStateId, nameof(newStateId));
            if (newStateId == StateId)
            {
                return;
            }

            StateId = newStateId;
            var cityUpdatedEvent = new CityUpdatedEvent(this, "Mongo-History");
            Events.Add(cityUpdatedEvent);
        }


        public void AddNewAddress(Address address)
        {
            Guard.Against.Null(address, nameof(address));
            Guard.Against.NullOrEmpty(address.AddressId, nameof(address.AddressId));
            Guard.Against.DuplicateAddress(_addresses, address, nameof(address));
            _addresses.Add(address);
            var addressAddedEvent = new AddressCreatedEvent(address, "Mongo-History");
            Events.Add(addressAddedEvent);
        }

        public void DeleteAddress(Address address)
        {
            Guard.Against.Null(address, nameof(address));
            var addressToDelete = _addresses
                .Where(a => a.AddressId == address.AddressId)
                .FirstOrDefault();
            if (addressToDelete != null)
            {
                _addresses.Remove(addressToDelete);
                var addressDeletedEvent = new AddressDeletedEvent(addressToDelete, "Mongo-History");
                Events.Add(addressDeletedEvent);
            }
        }
    }
}
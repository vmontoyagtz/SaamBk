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
    public class State : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Address> _addresses = new();

        private readonly List<City> _cities = new();

        private State() { } // EF required

        //[SetsRequiredMembers]
        public State(Guid stateId, Guid countryId, string stateName, Guid tenantId)
        {
            StateId = Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            CountryId = Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            StateName = Guard.Against.NullOrWhiteSpace(stateName, nameof(stateName));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid StateId { get; private set; }

        public string StateName { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Country Country { get; private set; }

        public Guid CountryId { get; private set; }
        public IEnumerable<Address> Addresses => _addresses.AsReadOnly();
        public IEnumerable<City> Cities => _cities.AsReadOnly();

        public void SetStateName(string stateName)
        {
            StateName = Guard.Against.NullOrEmpty(stateName, nameof(stateName));
        }

        public void UpdateCountryForState(Guid newCountryId)
        {
            Guard.Against.NullOrEmpty(newCountryId, nameof(newCountryId));
            if (newCountryId == CountryId)
            {
                return;
            }

            CountryId = newCountryId;
            var stateUpdatedEvent = new StateUpdatedEvent(this, "Mongo-History");
            Events.Add(stateUpdatedEvent);
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

        public void AddNewCity(City city)
        {
            Guard.Against.Null(city, nameof(city));
            Guard.Against.NullOrEmpty(city.CityId, nameof(city.CityId));
            Guard.Against.DuplicateCity(_cities, city, nameof(city));
            _cities.Add(city);
            var cityAddedEvent = new CityCreatedEvent(city, "Mongo-History");
            Events.Add(cityAddedEvent);
        }

        public void DeleteCity(City city)
        {
            Guard.Against.Null(city, nameof(city));
            var cityToDelete = _cities
                .Where(c => c.CityId == city.CityId)
                .FirstOrDefault();
            if (cityToDelete != null)
            {
                _cities.Remove(cityToDelete);
                var cityDeletedEvent = new CityDeletedEvent(cityToDelete, "Mongo-History");
                Events.Add(cityDeletedEvent);
            }
        }
    }
}
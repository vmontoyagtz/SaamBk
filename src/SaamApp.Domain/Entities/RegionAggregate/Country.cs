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
    public class Country : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Address> _addresses = new();

        private readonly List<IdentityDocument> _identityDocuments = new();

        private readonly List<State> _states = new();

        private Country() { } // EF required

        //[SetsRequiredMembers]
        public Country(Guid countryId, Guid regionId, string countryName, string countryCode, Guid tenantId)
        {
            CountryId = Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            CountryName = Guard.Against.NullOrWhiteSpace(countryName, nameof(countryName));
            CountryCode = Guard.Against.NullOrWhiteSpace(countryCode, nameof(countryCode));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid CountryId { get; private set; }

        public string CountryName { get; private set; }

        public string CountryCode { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Region Region { get; private set; }

        public Guid RegionId { get; private set; }
        public IEnumerable<Address> Addresses => _addresses.AsReadOnly();
        public IEnumerable<IdentityDocument> IdentityDocuments => _identityDocuments.AsReadOnly();
        public IEnumerable<State> States => _states.AsReadOnly();

        public void SetCountryName(string countryName)
        {
            CountryName = Guard.Against.NullOrEmpty(countryName, nameof(countryName));
        }

        public void SetCountryCode(string countryCode)
        {
            CountryCode = Guard.Against.NullOrEmpty(countryCode, nameof(countryCode));
        }

        public void UpdateRegionForCountry(Guid newRegionId)
        {
            Guard.Against.NullOrEmpty(newRegionId, nameof(newRegionId));
            if (newRegionId == RegionId)
            {
                return;
            }

            RegionId = newRegionId;
            var countryUpdatedEvent = new CountryUpdatedEvent(this, "Mongo-History");
            Events.Add(countryUpdatedEvent);
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

        public void AddNewIdentityDocument(IdentityDocument identityDocument)
        {
            Guard.Against.Null(identityDocument, nameof(identityDocument));
            Guard.Against.NullOrEmpty(identityDocument.IdentityDocumentId, nameof(identityDocument.IdentityDocumentId));
            Guard.Against.DuplicateIdentityDocument(_identityDocuments, identityDocument, nameof(identityDocument));
            _identityDocuments.Add(identityDocument);
            var identityDocumentAddedEvent = new IdentityDocumentCreatedEvent(identityDocument, "Mongo-History");
            Events.Add(identityDocumentAddedEvent);
        }

        public void DeleteIdentityDocument(IdentityDocument identityDocument)
        {
            Guard.Against.Null(identityDocument, nameof(identityDocument));
            var identityDocumentToDelete = _identityDocuments
                .Where(id => id.IdentityDocumentId == identityDocument.IdentityDocumentId)
                .FirstOrDefault();
            if (identityDocumentToDelete != null)
            {
                _identityDocuments.Remove(identityDocumentToDelete);
                var identityDocumentDeletedEvent =
                    new IdentityDocumentDeletedEvent(identityDocumentToDelete, "Mongo-History");
                Events.Add(identityDocumentDeletedEvent);
            }
        }

        public void AddNewState(State state)
        {
            Guard.Against.Null(state, nameof(state));
            Guard.Against.NullOrEmpty(state.StateId, nameof(state.StateId));
            Guard.Against.DuplicateState(_states, state, nameof(state));
            _states.Add(state);
            var stateAddedEvent = new StateCreatedEvent(state, "Mongo-History");
            Events.Add(stateAddedEvent);
        }

        public void DeleteState(State state)
        {
            Guard.Against.Null(state, nameof(state));
            var stateToDelete = _states
                .Where(s => s.StateId == state.StateId)
                .FirstOrDefault();
            if (stateToDelete != null)
            {
                _states.Remove(stateToDelete);
                var stateDeletedEvent = new StateDeletedEvent(stateToDelete, "Mongo-History");
                Events.Add(stateDeletedEvent);
            }
        }
    }
}
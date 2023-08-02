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
    public class Region : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Address> _addresses = new();

        private readonly List<Country> _countries = new();

        private readonly List<DiscountCode> _discountCodes = new();

        private readonly List<GiftCode> _giftCodes = new();

        private readonly List<PrepaidPackage> _prepaidPackages = new();

        private readonly List<RegionAreaAdvisorCategory> _regionAreaAdvisorCategories = new();

        private Region() { } // EF required

        //[SetsRequiredMembers]
        public Region(Guid regionId, string regionName, string regionCode, Guid tenantId)
        {
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            RegionName = Guard.Against.NullOrWhiteSpace(regionName, nameof(regionName));
            RegionCode = Guard.Against.NullOrWhiteSpace(regionCode, nameof(regionCode));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid RegionId { get; private set; }

        public string RegionName { get; private set; }

        public string RegionCode { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Address> Addresses => _addresses.AsReadOnly();
        public IEnumerable<Country> Countries => _countries.AsReadOnly();
        public IEnumerable<DiscountCode> DiscountCodes => _discountCodes.AsReadOnly();
        public IEnumerable<GiftCode> GiftCodes => _giftCodes.AsReadOnly();
        public IEnumerable<PrepaidPackage> PrepaidPackages => _prepaidPackages.AsReadOnly();

        public IEnumerable<RegionAreaAdvisorCategory> RegionAreaAdvisorCategories =>
            _regionAreaAdvisorCategories.AsReadOnly();

        public void SetRegionName(string regionName)
        {
            RegionName = Guard.Against.NullOrEmpty(regionName, nameof(regionName));
        }

        public void SetRegionCode(string regionCode)
        {
            RegionCode = Guard.Against.NullOrEmpty(regionCode, nameof(regionCode));
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

        public void AddNewCountry(Country country)
        {
            Guard.Against.Null(country, nameof(country));
            Guard.Against.NullOrEmpty(country.CountryId, nameof(country.CountryId));
            Guard.Against.DuplicateCountry(_countries, country, nameof(country));
            _countries.Add(country);
            var countryAddedEvent = new CountryCreatedEvent(country, "Mongo-History");
            Events.Add(countryAddedEvent);
        }

        public void DeleteCountry(Country country)
        {
            Guard.Against.Null(country, nameof(country));
            var countryToDelete = _countries
                .Where(c => c.CountryId == country.CountryId)
                .FirstOrDefault();
            if (countryToDelete != null)
            {
                _countries.Remove(countryToDelete);
                var countryDeletedEvent = new CountryDeletedEvent(countryToDelete, "Mongo-History");
                Events.Add(countryDeletedEvent);
            }
        }

        public void AddNewDiscountCode(DiscountCode discountCode)
        {
            Guard.Against.Null(discountCode, nameof(discountCode));
            Guard.Against.NullOrEmpty(discountCode.DiscountCodeId, nameof(discountCode.DiscountCodeId));
            Guard.Against.DuplicateDiscountCode(_discountCodes, discountCode, nameof(discountCode));
            _discountCodes.Add(discountCode);
            var discountCodeAddedEvent = new DiscountCodeCreatedEvent(discountCode, "Mongo-History");
            Events.Add(discountCodeAddedEvent);
        }

        public void DeleteDiscountCode(DiscountCode discountCode)
        {
            Guard.Against.Null(discountCode, nameof(discountCode));
            var discountCodeToDelete = _discountCodes
                .Where(dc => dc.DiscountCodeId == discountCode.DiscountCodeId)
                .FirstOrDefault();
            if (discountCodeToDelete != null)
            {
                _discountCodes.Remove(discountCodeToDelete);
                var discountCodeDeletedEvent = new DiscountCodeDeletedEvent(discountCodeToDelete, "Mongo-History");
                Events.Add(discountCodeDeletedEvent);
            }
        }

        public void AddNewGiftCode(GiftCode giftCode)
        {
            Guard.Against.Null(giftCode, nameof(giftCode));
            Guard.Against.NullOrEmpty(giftCode.GiftCodeId, nameof(giftCode.GiftCodeId));
            Guard.Against.DuplicateGiftCode(_giftCodes, giftCode, nameof(giftCode));
            _giftCodes.Add(giftCode);
            var giftCodeAddedEvent = new GiftCodeCreatedEvent(giftCode, "Mongo-History");
            Events.Add(giftCodeAddedEvent);
        }

        public void DeleteGiftCode(GiftCode giftCode)
        {
            Guard.Against.Null(giftCode, nameof(giftCode));
            var giftCodeToDelete = _giftCodes
                .Where(gc => gc.GiftCodeId == giftCode.GiftCodeId)
                .FirstOrDefault();
            if (giftCodeToDelete != null)
            {
                _giftCodes.Remove(giftCodeToDelete);
                var giftCodeDeletedEvent = new GiftCodeDeletedEvent(giftCodeToDelete, "Mongo-History");
                Events.Add(giftCodeDeletedEvent);
            }
        }

        public void AddNewPrepaidPackage(PrepaidPackage prepaidPackage)
        {
            Guard.Against.Null(prepaidPackage, nameof(prepaidPackage));
            Guard.Against.NullOrEmpty(prepaidPackage.PrepaidPackageId, nameof(prepaidPackage.PrepaidPackageId));
            Guard.Against.DuplicatePrepaidPackage(_prepaidPackages, prepaidPackage, nameof(prepaidPackage));
            _prepaidPackages.Add(prepaidPackage);
            var prepaidPackageAddedEvent = new PrepaidPackageCreatedEvent(prepaidPackage, "Mongo-History");
            Events.Add(prepaidPackageAddedEvent);
        }

        public void DeletePrepaidPackage(PrepaidPackage prepaidPackage)
        {
            Guard.Against.Null(prepaidPackage, nameof(prepaidPackage));
            var prepaidPackageToDelete = _prepaidPackages
                .Where(pp => pp.PrepaidPackageId == prepaidPackage.PrepaidPackageId)
                .FirstOrDefault();
            if (prepaidPackageToDelete != null)
            {
                _prepaidPackages.Remove(prepaidPackageToDelete);
                var prepaidPackageDeletedEvent =
                    new PrepaidPackageDeletedEvent(prepaidPackageToDelete, "Mongo-History");
                Events.Add(prepaidPackageDeletedEvent);
            }
        }

        public void AddNewRegionAreaAdvisorCategory(RegionAreaAdvisorCategory regionAreaAdvisorCategory)
        {
            Guard.Against.Null(regionAreaAdvisorCategory, nameof(regionAreaAdvisorCategory));
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId,
                nameof(regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId));
            Guard.Against.DuplicateRegionAreaAdvisorCategory(_regionAreaAdvisorCategories, regionAreaAdvisorCategory,
                nameof(regionAreaAdvisorCategory));
            _regionAreaAdvisorCategories.Add(regionAreaAdvisorCategory);
            var regionAreaAdvisorCategoryAddedEvent =
                new RegionAreaAdvisorCategoryCreatedEvent(regionAreaAdvisorCategory, "Mongo-History");
            Events.Add(regionAreaAdvisorCategoryAddedEvent);
        }

        public void DeleteRegionAreaAdvisorCategory(RegionAreaAdvisorCategory regionAreaAdvisorCategory)
        {
            Guard.Against.Null(regionAreaAdvisorCategory, nameof(regionAreaAdvisorCategory));
            var regionAreaAdvisorCategoryToDelete = _regionAreaAdvisorCategories
                .Where(raac =>
                    raac.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId)
                .FirstOrDefault();
            if (regionAreaAdvisorCategoryToDelete != null)
            {
                _regionAreaAdvisorCategories.Remove(regionAreaAdvisorCategoryToDelete);
                var regionAreaAdvisorCategoryDeletedEvent =
                    new RegionAreaAdvisorCategoryDeletedEvent(regionAreaAdvisorCategoryToDelete, "Mongo-History");
                Events.Add(regionAreaAdvisorCategoryDeletedEvent);
            }
        }
    }
}
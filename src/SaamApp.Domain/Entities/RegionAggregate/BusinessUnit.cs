using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class BusinessUnit : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Advisor> _advisors = new();

        private readonly List<BusinessUnitAddress> _businessUnitAddresses = new();

        private readonly List<BusinessUnitCategory> _businessUnitCategories = new();

        private readonly List<BusinessUnitDocument> _businessUnitDocuments = new();

        private readonly List<BusinessUnitEmailAddress> _businessUnitEmailAddresses = new();

        private readonly List<BusinessUnitPhoneNumber> _businessUnitPhoneNumbers = new();

        private readonly List<TaxInformation> _taxInformations = new();


        private BusinessUnit() { } // EF required

        //[SetsRequiredMembers]
        public BusinessUnit(Guid businessUnitId, string businessUnitName, Guid businessAddressId,
            Guid businessPhoneNumberId, Guid businessEmailAddressId, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            BusinessUnitName = Guard.Against.NullOrWhiteSpace(businessUnitName, nameof(businessUnitName));
            BusinessAddressId = Guard.Against.NullOrEmpty(businessAddressId, nameof(businessAddressId));
            BusinessPhoneNumberId = Guard.Against.NullOrEmpty(businessPhoneNumberId, nameof(businessPhoneNumberId));
            BusinessEmailAddressId = Guard.Against.NullOrEmpty(businessEmailAddressId, nameof(businessEmailAddressId));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid BusinessUnitId { get; private set; }

        public string BusinessUnitName { get; private set; }

        public Guid BusinessAddressId { get; private set; }

        public Guid BusinessPhoneNumberId { get; private set; }

        public Guid BusinessEmailAddressId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Advisor> Advisors => _advisors.AsReadOnly();
        public IEnumerable<BusinessUnitAddress> BusinessUnitAddresses => _businessUnitAddresses.AsReadOnly();
        public IEnumerable<BusinessUnitCategory> BusinessUnitCategories => _businessUnitCategories.AsReadOnly();
        public IEnumerable<BusinessUnitDocument> BusinessUnitDocuments => _businessUnitDocuments.AsReadOnly();

        public IEnumerable<BusinessUnitEmailAddress> BusinessUnitEmailAddresses =>
            _businessUnitEmailAddresses.AsReadOnly();

        public IEnumerable<BusinessUnitPhoneNumber> BusinessUnitPhoneNumbers => _businessUnitPhoneNumbers.AsReadOnly();
        public IEnumerable<TaxInformation> TaxInformations => _taxInformations.AsReadOnly();

        public void SetBusinessUnitName(string businessUnitName)
        {
            BusinessUnitName = Guard.Against.NullOrEmpty(businessUnitName, nameof(businessUnitName));
        }
    }
}
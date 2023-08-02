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
    public class TaxInformation : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Account> _accounts = new();

        private readonly List<Advisor> _advisors = new();

        private TaxInformation() { } // EF required

        //[SetsRequiredMembers]
        public TaxInformation(Guid taxInformationId, Guid businessUnitId, Guid taxpayerTypeId, Guid businessTypeId,
            string? taxInformationBusinessName, string? taxInformationCommercialName, Guid taxInformationRegistrationId,
            string? taxInformationBusinessIndustry, DateTime createdAt, Guid createdBy, DateTime? updatedAt,
            Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            TaxInformationId = Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            TaxpayerTypeId = Guard.Against.NullOrEmpty(taxpayerTypeId, nameof(taxpayerTypeId));
            BusinessTypeId = Guard.Against.NullOrEmpty(businessTypeId, nameof(businessTypeId));
            TaxInformationBusinessName = taxInformationBusinessName;
            TaxInformationCommercialName = taxInformationCommercialName;
            TaxInformationRegistrationId =
                Guard.Against.NullOrEmpty(taxInformationRegistrationId, nameof(taxInformationRegistrationId));
            TaxInformationBusinessIndustry = taxInformationBusinessIndustry;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid TaxInformationId { get; private set; }

        public Guid BusinessTypeId { get; private set; }

        public string? TaxInformationBusinessName { get; private set; }

        public string? TaxInformationCommercialName { get; private set; }

        public Guid TaxInformationRegistrationId { get; private set; }

        public string? TaxInformationBusinessIndustry { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual BusinessUnit BusinessUnit { get; private set; }

        public Guid BusinessUnitId { get; private set; }

        public virtual TaxpayerType TaxpayerType { get; private set; }

        public Guid TaxpayerTypeId { get; private set; }
        public IEnumerable<Account> Accounts => _accounts.AsReadOnly();
        public IEnumerable<Advisor> Advisors => _advisors.AsReadOnly();

        public void SetTaxInformationBusinessName(string taxInformationBusinessName)
        {
            TaxInformationBusinessName = taxInformationBusinessName;
        }

        public void SetTaxInformationCommercialName(string taxInformationCommercialName)
        {
            TaxInformationCommercialName = taxInformationCommercialName;
        }

        public void SetTaxInformationBusinessIndustry(string taxInformationBusinessIndustry)
        {
            TaxInformationBusinessIndustry = taxInformationBusinessIndustry;
        }

        public void UpdateBusinessUnitForTaxInformation(Guid newBusinessUnitId)
        {
            Guard.Against.NullOrEmpty(newBusinessUnitId, nameof(newBusinessUnitId));
            if (newBusinessUnitId == BusinessUnitId)
            {
                return;
            }

            BusinessUnitId = newBusinessUnitId;
            var taxInformationUpdatedEvent = new TaxInformationUpdatedEvent(this, "Mongo-History");
            Events.Add(taxInformationUpdatedEvent);
        }


        public void UpdateTaxpayerTypeForTaxInformation(Guid newTaxpayerTypeId)
        {
            Guard.Against.NullOrEmpty(newTaxpayerTypeId, nameof(newTaxpayerTypeId));
            if (newTaxpayerTypeId == TaxpayerTypeId)
            {
                return;
            }

            TaxpayerTypeId = newTaxpayerTypeId;
            var taxInformationUpdatedEvent = new TaxInformationUpdatedEvent(this, "Mongo-History");
            Events.Add(taxInformationUpdatedEvent);
        }


        public void AddNewAccount(Account account)
        {
            Guard.Against.Null(account, nameof(account));
            Guard.Against.NullOrEmpty(account.AccountId, nameof(account.AccountId));
            Guard.Against.DuplicateAccount(_accounts, account, nameof(account));
            _accounts.Add(account);
            var accountAddedEvent = new AccountCreatedEvent(account, "Mongo-History");
            Events.Add(accountAddedEvent);
        }

        public void DeleteAccount(Account account)
        {
            Guard.Against.Null(account, nameof(account));
            var accountToDelete = _accounts
                .Where(a => a.AccountId == account.AccountId)
                .FirstOrDefault();
            if (accountToDelete != null)
            {
                _accounts.Remove(accountToDelete);
                var accountDeletedEvent = new AccountDeletedEvent(accountToDelete, "Mongo-History");
                Events.Add(accountDeletedEvent);
            }
        }

        public void AddNewAdvisor(Advisor advisor)
        {
            Guard.Against.Null(advisor, nameof(advisor));
            Guard.Against.NullOrEmpty(advisor.AdvisorId, nameof(advisor.AdvisorId));
            Guard.Against.DuplicateAdvisor(_advisors, advisor, nameof(advisor));
            _advisors.Add(advisor);
            var advisorAddedEvent = new AdvisorCreatedEvent(advisor, "Mongo-History");
            Events.Add(advisorAddedEvent);
        }

        public void DeleteAdvisor(Advisor advisor)
        {
            Guard.Against.Null(advisor, nameof(advisor));
            var advisorToDelete = _advisors
                .Where(a => a.AdvisorId == advisor.AdvisorId)
                .FirstOrDefault();
            if (advisorToDelete != null)
            {
                _advisors.Remove(advisorToDelete);
                var advisorDeletedEvent = new AdvisorDeletedEvent(advisorToDelete, "Mongo-History");
                Events.Add(advisorDeletedEvent);
            }
        }
    }
}
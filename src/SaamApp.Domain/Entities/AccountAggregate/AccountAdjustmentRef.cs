using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AccountAdjustmentRef : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AccountAdjustment> _accountAdjustments = new();


        private AccountAdjustmentRef() { } // EF required

        //[SetsRequiredMembers]
        public AccountAdjustmentRef(Guid accountAdjustmentRefId, string accountAdjustmentRefName,
            string accountAdjustmentRefDescription, Guid tenantId)
        {
            AccountAdjustmentRefId = Guard.Against.NullOrEmpty(accountAdjustmentRefId, nameof(accountAdjustmentRefId));
            AccountAdjustmentRefName =
                Guard.Against.NullOrWhiteSpace(accountAdjustmentRefName, nameof(accountAdjustmentRefName));
            AccountAdjustmentRefDescription = Guard.Against.NullOrWhiteSpace(accountAdjustmentRefDescription,
                nameof(accountAdjustmentRefDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AccountAdjustmentRefId { get; private set; }

        public string AccountAdjustmentRefName { get; private set; }

        public string AccountAdjustmentRefDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AccountAdjustment> AccountAdjustments => _accountAdjustments.AsReadOnly();

        public void SetAccountAdjustmentRefName(string accountAdjustmentRefName)
        {
            AccountAdjustmentRefName =
                Guard.Against.NullOrEmpty(accountAdjustmentRefName, nameof(accountAdjustmentRefName));
        }

        public void SetAccountAdjustmentRefDescription(string accountAdjustmentRefDescription)
        {
            AccountAdjustmentRefDescription = Guard.Against.NullOrEmpty(accountAdjustmentRefDescription,
                nameof(accountAdjustmentRefDescription));
        }
    }
}
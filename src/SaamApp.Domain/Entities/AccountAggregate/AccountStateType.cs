using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AccountStateType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Account> _accounts = new();


        private AccountStateType() { } // EF required

        //[SetsRequiredMembers]
        public AccountStateType(Guid accountStateTypeId, string accountStateTypeCode, string accountStateTypeName,
            string? accountStateTypeDescription, Guid tenantId)
        {
            AccountStateTypeId = Guard.Against.NullOrEmpty(accountStateTypeId, nameof(accountStateTypeId));
            AccountStateTypeCode = Guard.Against.NullOrWhiteSpace(accountStateTypeCode, nameof(accountStateTypeCode));
            AccountStateTypeName = Guard.Against.NullOrWhiteSpace(accountStateTypeName, nameof(accountStateTypeName));
            AccountStateTypeDescription = accountStateTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AccountStateTypeId { get; private set; }

        public string AccountStateTypeCode { get; private set; }

        public string AccountStateTypeName { get; private set; }

        public string? AccountStateTypeDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Account> Accounts => _accounts.AsReadOnly();

        public void SetAccountStateTypeCode(string accountStateTypeCode)
        {
            AccountStateTypeCode = Guard.Against.NullOrEmpty(accountStateTypeCode, nameof(accountStateTypeCode));
        }

        public void SetAccountStateTypeName(string accountStateTypeName)
        {
            AccountStateTypeName = Guard.Against.NullOrEmpty(accountStateTypeName, nameof(accountStateTypeName));
        }

        public void SetAccountStateTypeDescription(string accountStateTypeDescription)
        {
            AccountStateTypeDescription = accountStateTypeDescription;
        }
    }
}
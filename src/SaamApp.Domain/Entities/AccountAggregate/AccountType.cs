using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AccountType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Account> _accounts = new();


        private AccountType() { } // EF required

        //[SetsRequiredMembers]
        public AccountType(Guid accountTypeId, string accountTypeCode, string accountTypeName,
            string accountTypeDescription, Guid tenantId)
        {
            AccountTypeId = Guard.Against.NullOrEmpty(accountTypeId, nameof(accountTypeId));
            AccountTypeCode = Guard.Against.NullOrWhiteSpace(accountTypeCode, nameof(accountTypeCode));
            AccountTypeName = Guard.Against.NullOrWhiteSpace(accountTypeName, nameof(accountTypeName));
            AccountTypeDescription =
                Guard.Against.NullOrWhiteSpace(accountTypeDescription, nameof(accountTypeDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AccountTypeId { get; private set; }

        public string AccountTypeCode { get; private set; }

        public string AccountTypeName { get; private set; }

        public string AccountTypeDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Account> Accounts => _accounts.AsReadOnly();

        public void SetAccountTypeCode(string accountTypeCode)
        {
            AccountTypeCode = Guard.Against.NullOrEmpty(accountTypeCode, nameof(accountTypeCode));
        }

        public void SetAccountTypeName(string accountTypeName)
        {
            AccountTypeName = Guard.Against.NullOrEmpty(accountTypeName, nameof(accountTypeName));
        }

        public void SetAccountTypeDescription(string accountTypeDescription)
        {
            AccountTypeDescription = Guard.Against.NullOrEmpty(accountTypeDescription, nameof(accountTypeDescription));
        }
    }
}
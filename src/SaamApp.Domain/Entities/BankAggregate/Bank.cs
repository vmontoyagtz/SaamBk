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
    public class Bank : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<BankAccount> _bankAccounts = new();

        private Bank() { } // EF required

        //[SetsRequiredMembers]
        public Bank(Guid bankId, string bankName, string? bankSwiftCodeInfo, string bankAddress, string bankPhoneNumber,
            string bankEmailAddress, string bankNotes, DateTime createdAt, Guid createdBy, DateTime? updatedAt,
            Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            BankId = Guard.Against.NullOrEmpty(bankId, nameof(bankId));
            BankName = Guard.Against.NullOrWhiteSpace(bankName, nameof(bankName));
            BankSwiftCodeInfo = bankSwiftCodeInfo;
            BankAddress = Guard.Against.NullOrWhiteSpace(bankAddress, nameof(bankAddress));
            BankPhoneNumber = Guard.Against.NullOrWhiteSpace(bankPhoneNumber, nameof(bankPhoneNumber));
            BankEmailAddress = Guard.Against.NullOrWhiteSpace(bankEmailAddress, nameof(bankEmailAddress));
            BankNotes = Guard.Against.NullOrWhiteSpace(bankNotes, nameof(bankNotes));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid BankId { get; private set; }

        public string BankName { get; private set; }

        public string? BankSwiftCodeInfo { get; private set; }

        public string BankAddress { get; private set; }

        public string BankPhoneNumber { get; private set; }

        public string BankEmailAddress { get; private set; }

        public string BankNotes { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<BankAccount> BankAccounts => _bankAccounts.AsReadOnly();

        public void SetBankName(string bankName)
        {
            BankName = Guard.Against.NullOrEmpty(bankName, nameof(bankName));
        }

        public void SetBankSwiftCodeInfo(string bankSwiftCodeInfo)
        {
            BankSwiftCodeInfo = bankSwiftCodeInfo;
        }

        public void SetBankAddress(string bankAddress)
        {
            BankAddress = Guard.Against.NullOrEmpty(bankAddress, nameof(bankAddress));
        }

        public void SetBankPhoneNumber(string bankPhoneNumber)
        {
            BankPhoneNumber = Guard.Against.NullOrEmpty(bankPhoneNumber, nameof(bankPhoneNumber));
        }

        public void SetBankEmailAddress(string bankEmailAddress)
        {
            BankEmailAddress = Guard.Against.NullOrEmpty(bankEmailAddress, nameof(bankEmailAddress));
        }

        public void SetBankNotes(string bankNotes)
        {
            BankNotes = Guard.Against.NullOrEmpty(bankNotes, nameof(bankNotes));
        }


        public void AddNewBankAccount(BankAccount bankAccount)
        {
            Guard.Against.Null(bankAccount, nameof(bankAccount));
            Guard.Against.NullOrEmpty(bankAccount.BankAccountId, nameof(bankAccount.BankAccountId));
            Guard.Against.DuplicateBankAccount(_bankAccounts, bankAccount, nameof(bankAccount));
            _bankAccounts.Add(bankAccount);
            var bankAccountAddedEvent = new BankAccountCreatedEvent(bankAccount, "Mongo-History");
            Events.Add(bankAccountAddedEvent);
        }

        public void DeleteBankAccount(BankAccount bankAccount)
        {
            Guard.Against.Null(bankAccount, nameof(bankAccount));
            var bankAccountToDelete = _bankAccounts
                .Where(ba => ba.BankAccountId == bankAccount.BankAccountId)
                .FirstOrDefault();
            if (bankAccountToDelete != null)
            {
                _bankAccounts.Remove(bankAccountToDelete);
                var bankAccountDeletedEvent = new BankAccountDeletedEvent(bankAccountToDelete, "Mongo-History");
                Events.Add(bankAccountDeletedEvent);
            }
        }
    }
}
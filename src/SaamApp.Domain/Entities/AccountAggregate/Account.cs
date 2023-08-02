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
    public class Account : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AccountAdjustment> _accountAdjustments = new();

        private readonly List<CustomerAccount> _customerAccounts = new();

        private readonly List<Invoice> _invoices = new();

        private readonly List<JournalEntryLine> _journalEntryLines = new();

        private Account() { } // EF required

        //[SetsRequiredMembers]
        public Account(Guid accountId, Guid accountStateTypeId, Guid accountTypeId, Guid taxInformationId,
            string accountNumber, string accountName, string accountDescription, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            AccountStateTypeId = Guard.Against.NullOrEmpty(accountStateTypeId, nameof(accountStateTypeId));
            AccountTypeId = Guard.Against.NullOrEmpty(accountTypeId, nameof(accountTypeId));
            TaxInformationId = Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            AccountNumber = Guard.Against.NullOrWhiteSpace(accountNumber, nameof(accountNumber));
            AccountName = Guard.Against.NullOrWhiteSpace(accountName, nameof(accountName));
            AccountDescription = Guard.Against.NullOrWhiteSpace(accountDescription, nameof(accountDescription));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AccountId { get; private set; }

        public string AccountNumber { get; private set; }

        public string AccountName { get; private set; }

        public string AccountDescription { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual AccountStateType AccountStateType { get; private set; }

        public Guid AccountStateTypeId { get; private set; }

        public virtual AccountType AccountType { get; private set; }

        public Guid AccountTypeId { get; private set; }

        public virtual TaxInformation TaxInformation { get; private set; }

        public Guid TaxInformationId { get; private set; }
        public IEnumerable<AccountAdjustment> AccountAdjustments => _accountAdjustments.AsReadOnly();
        public IEnumerable<CustomerAccount> CustomerAccounts => _customerAccounts.AsReadOnly();
        public IEnumerable<Invoice> Invoices => _invoices.AsReadOnly();
        public IEnumerable<JournalEntryLine> JournalEntryLines => _journalEntryLines.AsReadOnly();

        public void SetAccountNumber(string accountNumber)
        {
            AccountNumber = Guard.Against.NullOrEmpty(accountNumber, nameof(accountNumber));
        }

        public void SetAccountName(string accountName)
        {
            AccountName = Guard.Against.NullOrEmpty(accountName, nameof(accountName));
        }

        public void SetAccountDescription(string accountDescription)
        {
            AccountDescription = Guard.Against.NullOrEmpty(accountDescription, nameof(accountDescription));
        }

        public void UpdateAccountStateTypeForAccount(Guid newAccountStateTypeId)
        {
            Guard.Against.NullOrEmpty(newAccountStateTypeId, nameof(newAccountStateTypeId));
            if (newAccountStateTypeId == AccountStateTypeId)
            {
                return;
            }

            AccountStateTypeId = newAccountStateTypeId;
            var accountUpdatedEvent = new AccountUpdatedEvent(this, "Mongo-History");
            Events.Add(accountUpdatedEvent);
        }


        public void UpdateAccountTypeForAccount(Guid newAccountTypeId)
        {
            Guard.Against.NullOrEmpty(newAccountTypeId, nameof(newAccountTypeId));
            if (newAccountTypeId == AccountTypeId)
            {
                return;
            }

            AccountTypeId = newAccountTypeId;
            var accountUpdatedEvent = new AccountUpdatedEvent(this, "Mongo-History");
            Events.Add(accountUpdatedEvent);
        }


        public void UpdateTaxInformationForAccount(Guid newTaxInformationId)
        {
            Guard.Against.NullOrEmpty(newTaxInformationId, nameof(newTaxInformationId));
            if (newTaxInformationId == TaxInformationId)
            {
                return;
            }

            TaxInformationId = newTaxInformationId;
            var accountUpdatedEvent = new AccountUpdatedEvent(this, "Mongo-History");
            Events.Add(accountUpdatedEvent);
        }


        public void AddNewAccountAdjustment(AccountAdjustment accountAdjustment)
        {
            Guard.Against.Null(accountAdjustment, nameof(accountAdjustment));
            Guard.Against.NullOrEmpty(
                accountAdjustment.AccountAdjustmentId,
                nameof(accountAdjustment.AccountAdjustmentId));
            Guard.Against.DuplicateAccountAdjustment(_accountAdjustments, accountAdjustment, nameof(accountAdjustment));
            _accountAdjustments.Add(accountAdjustment);
            var accountAdjustmentAddedEvent = new AccountAdjustmentCreatedEvent(accountAdjustment, "Mongo-History");
            Events.Add(accountAdjustmentAddedEvent);
        }

        public void DeleteAccountAdjustment(AccountAdjustment accountAdjustment)
        {
            Guard.Against.Null(accountAdjustment, nameof(accountAdjustment));
            var accountAdjustmentToDelete = _accountAdjustments
                .Where(aa => aa.AccountAdjustmentId == accountAdjustment.AccountAdjustmentId)
                .FirstOrDefault();
            if (accountAdjustmentToDelete != null)
            {
                _accountAdjustments.Remove(accountAdjustmentToDelete);
                var accountAdjustmentDeletedEvent =
                    new AccountAdjustmentDeletedEvent(accountAdjustmentToDelete, "Mongo-History");
                Events.Add(accountAdjustmentDeletedEvent);
            }
        }

        public void AddNewCustomerAccount(Guid accountId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var newCustomerAccount = new CustomerAccount(accountId, customerId);
            Guard.Against.DuplicateCustomerAccount(_customerAccounts, newCustomerAccount, nameof(newCustomerAccount));
            _customerAccounts.Add(newCustomerAccount);
            var customerAccountAddedEvent = new CustomerAccountCreatedEvent(newCustomerAccount, "Mongo-History");
            Events.Add(customerAccountAddedEvent);
        }

        public void DeleteCustomerAccount(Guid accountId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var customerAccountToDelete = _customerAccounts
                .Where(ca1 => ca1.AccountId == accountId)
                .Where(ca2 => ca2.CustomerId == customerId)
                .FirstOrDefault();

            if (customerAccountToDelete != null)
            {
                _customerAccounts.Remove(customerAccountToDelete);
                var customerAccountDeletedEvent =
                    new CustomerAccountDeletedEvent(customerAccountToDelete, "Mongo-History");
                Events.Add(customerAccountDeletedEvent);
            }
        }

        public void AddNewInvoice(Invoice invoice)
        {
            Guard.Against.Null(invoice, nameof(invoice));
            Guard.Against.NullOrEmpty(invoice.InvoiceId, nameof(invoice.InvoiceId));
            Guard.Against.DuplicateInvoice(_invoices, invoice, nameof(invoice));
            _invoices.Add(invoice);
            var invoiceAddedEvent = new InvoiceCreatedEvent(invoice, "Mongo-History");
            Events.Add(invoiceAddedEvent);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            Guard.Against.Null(invoice, nameof(invoice));
            var invoiceToDelete = _invoices
                .Where(i => i.InvoiceId == invoice.InvoiceId)
                .FirstOrDefault();
            if (invoiceToDelete != null)
            {
                _invoices.Remove(invoiceToDelete);
                var invoiceDeletedEvent = new InvoiceDeletedEvent(invoiceToDelete, "Mongo-History");
                Events.Add(invoiceDeletedEvent);
            }
        }

        public void AddNewJournalEntryLine(JournalEntryLine journalEntryLine)
        {
            Guard.Against.Null(journalEntryLine, nameof(journalEntryLine));
            Guard.Against.NullOrEmpty(journalEntryLine.JournalEntryLineId, nameof(journalEntryLine.JournalEntryLineId));
            Guard.Against.DuplicateJournalEntryLine(_journalEntryLines, journalEntryLine, nameof(journalEntryLine));
            _journalEntryLines.Add(journalEntryLine);
            var journalEntryLineAddedEvent = new JournalEntryLineCreatedEvent(journalEntryLine, "Mongo-History");
            Events.Add(journalEntryLineAddedEvent);
        }

        public void DeleteJournalEntryLine(JournalEntryLine journalEntryLine)
        {
            Guard.Against.Null(journalEntryLine, nameof(journalEntryLine));
            var journalEntryLineToDelete = _journalEntryLines
                .Where(jel => jel.JournalEntryLineId == journalEntryLine.JournalEntryLineId)
                .FirstOrDefault();
            if (journalEntryLineToDelete != null)
            {
                _journalEntryLines.Remove(journalEntryLineToDelete);
                var journalEntryLineDeletedEvent =
                    new JournalEntryLineDeletedEvent(journalEntryLineToDelete, "Mongo-History");
                Events.Add(journalEntryLineDeletedEvent);
            }
        }
    }
}
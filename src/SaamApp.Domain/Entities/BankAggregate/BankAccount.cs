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
    public class BankAccount : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorBank> _advisorBanks = new();

        private readonly List<AdvisorBankTransferInfo> _advisorBankTransferInfoes = new();

        private readonly List<AdvisorPayment> _advisorPayments = new();

        private BankAccount() { } // EF required

        //[SetsRequiredMembers]
        public BankAccount(Guid bankAccountId, Guid bankId, string bankAccountName, string bankAccountNumber,
            string bankAccountNotificationPhoneNumber, string bankAccountNotificationEmailAddress, string? description,
            bool isDefault, Guid tenantId)
        {
            BankAccountId = Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            BankId = Guard.Against.NullOrEmpty(bankId, nameof(bankId));
            BankAccountName = Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));
            BankAccountNumber = Guard.Against.NullOrWhiteSpace(bankAccountNumber, nameof(bankAccountNumber));
            BankAccountNotificationPhoneNumber = Guard.Against.NullOrWhiteSpace(bankAccountNotificationPhoneNumber,
                nameof(bankAccountNotificationPhoneNumber));
            BankAccountNotificationEmailAddress = Guard.Against.NullOrWhiteSpace(bankAccountNotificationEmailAddress,
                nameof(bankAccountNotificationEmailAddress));
            Description = description;
            IsDefault = Guard.Against.Null(isDefault, nameof(isDefault));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid BankAccountId { get; private set; }

        public string BankAccountName { get; private set; }

        public string BankAccountNumber { get; private set; }

        public string BankAccountNotificationPhoneNumber { get; private set; }

        public string BankAccountNotificationEmailAddress { get; private set; }

        public string? Description { get; private set; }

        public bool IsDefault { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Bank Bank { get; private set; }

        public Guid BankId { get; private set; }
        public IEnumerable<AdvisorBank> AdvisorBanks => _advisorBanks.AsReadOnly();

        public IEnumerable<AdvisorBankTransferInfo> AdvisorBankTransferInfoes =>
            _advisorBankTransferInfoes.AsReadOnly();

        public IEnumerable<AdvisorPayment> AdvisorPayments => _advisorPayments.AsReadOnly();

        public void SetBankAccountName(string bankAccountName)
        {
            BankAccountName = Guard.Against.NullOrEmpty(bankAccountName, nameof(bankAccountName));
        }

        public void SetBankAccountNumber(string bankAccountNumber)
        {
            BankAccountNumber = Guard.Against.NullOrEmpty(bankAccountNumber, nameof(bankAccountNumber));
        }

        public void SetBankAccountNotificationPhoneNumber(string bankAccountNotificationPhoneNumber)
        {
            BankAccountNotificationPhoneNumber = Guard.Against.NullOrEmpty(bankAccountNotificationPhoneNumber,
                nameof(bankAccountNotificationPhoneNumber));
        }

        public void SetBankAccountNotificationEmailAddress(string bankAccountNotificationEmailAddress)
        {
            BankAccountNotificationEmailAddress = Guard.Against.NullOrEmpty(bankAccountNotificationEmailAddress,
                nameof(bankAccountNotificationEmailAddress));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void UpdateBankForBankAccount(Guid newBankId)
        {
            Guard.Against.NullOrEmpty(newBankId, nameof(newBankId));
            if (newBankId == BankId)
            {
                return;
            }

            BankId = newBankId;
            var bankAccountUpdatedEvent = new BankAccountUpdatedEvent(this, "Mongo-History");
            Events.Add(bankAccountUpdatedEvent);
        }


        public void AddNewAdvisorBank(bool isDefault, Guid advisorId, Guid bankAccountId)
        {
            Guard.Against.Null(isDefault, nameof(isDefault));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));

            var newAdvisorBank = new AdvisorBank(advisorId, bankAccountId, isDefault);
            Guard.Against.DuplicateAdvisorBank(_advisorBanks, newAdvisorBank, nameof(newAdvisorBank));
            _advisorBanks.Add(newAdvisorBank);
            var advisorBankAddedEvent = new AdvisorBankCreatedEvent(newAdvisorBank, "Mongo-History");
            Events.Add(advisorBankAddedEvent);
        }

        public void DeleteAdvisorBank(bool isDefault, Guid advisorId, Guid bankAccountId)
        {
            Guard.Against.Null(isDefault, nameof(isDefault));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));

            var advisorBankToDelete = _advisorBanks
                .Where(ab1 => ab1.IsDefault == isDefault)
                .Where(ab2 => ab2.AdvisorId == advisorId)
                .Where(ab3 => ab3.BankAccountId == bankAccountId)
                .FirstOrDefault();

            if (advisorBankToDelete != null)
            {
                _advisorBanks.Remove(advisorBankToDelete);
                var advisorBankDeletedEvent = new AdvisorBankDeletedEvent(advisorBankToDelete, "Mongo-History");
                Events.Add(advisorBankDeletedEvent);
            }
        }

        public void AddNewAdvisorBankTransferInfo(AdvisorBankTransferInfo advisorBankTransferInfo)
        {
            Guard.Against.Null(advisorBankTransferInfo, nameof(advisorBankTransferInfo));
            Guard.Against.NullOrEmpty(advisorBankTransferInfo.AdvisorBankTransferInfoId,
                nameof(advisorBankTransferInfo.AdvisorBankTransferInfoId));
            Guard.Against.DuplicateAdvisorBankTransferInfo(_advisorBankTransferInfoes, advisorBankTransferInfo,
                nameof(advisorBankTransferInfo));
            _advisorBankTransferInfoes.Add(advisorBankTransferInfo);
            var advisorBankTransferInfoAddedEvent =
                new AdvisorBankTransferInfoCreatedEvent(advisorBankTransferInfo, "Mongo-History");
            Events.Add(advisorBankTransferInfoAddedEvent);
        }

        public void DeleteAdvisorBankTransferInfo(AdvisorBankTransferInfo advisorBankTransferInfo)
        {
            Guard.Against.Null(advisorBankTransferInfo, nameof(advisorBankTransferInfo));
            var advisorBankTransferInfoToDelete = _advisorBankTransferInfoes
                .Where(abti => abti.AdvisorBankTransferInfoId == advisorBankTransferInfo.AdvisorBankTransferInfoId)
                .FirstOrDefault();
            if (advisorBankTransferInfoToDelete != null)
            {
                _advisorBankTransferInfoes.Remove(advisorBankTransferInfoToDelete);
                var advisorBankTransferInfoDeletedEvent =
                    new AdvisorBankTransferInfoDeletedEvent(advisorBankTransferInfoToDelete, "Mongo-History");
                Events.Add(advisorBankTransferInfoDeletedEvent);
            }
        }

        public void AddNewAdvisorPayment(string advisorPaymentDescription, decimal advisorPaymentsAmount,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid advisorId,
            Guid bankAccountId, Guid paymentMethodId)
        {
            Guard.Against.NullOrWhiteSpace(advisorPaymentDescription, nameof(advisorPaymentDescription));
            Guard.Against.Negative(advisorPaymentsAmount, nameof(advisorPaymentsAmount));
            Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));

            var newAdvisorPayment = new AdvisorPayment(advisorId, bankAccountId, paymentMethodId,
                advisorPaymentDescription, advisorPaymentsAmount, createdAt, createdBy, updatedAt, updatedBy,
                isDeleted);
            Guard.Against.DuplicateAdvisorPayment(_advisorPayments, newAdvisorPayment, nameof(newAdvisorPayment));
            _advisorPayments.Add(newAdvisorPayment);
            var advisorPaymentAddedEvent = new AdvisorPaymentCreatedEvent(newAdvisorPayment, "Mongo-History");
            Events.Add(advisorPaymentAddedEvent);
        }

        public void DeleteAdvisorPayment(string advisorPaymentDescription, decimal advisorPaymentsAmount,
            DateTime createdAt, Guid createdBy, DateTime updatedAt, Guid updatedBy, bool isDeleted, Guid advisorId,
            Guid bankAccountId, Guid paymentMethodId)
        {
            Guard.Against.NullOrWhiteSpace(advisorPaymentDescription, nameof(advisorPaymentDescription));
            Guard.Against.Negative(advisorPaymentsAmount, nameof(advisorPaymentsAmount));
            Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            Guard.Against.OutOfSQLDateRange(updatedAt, nameof(updatedAt));
            Guard.Against.NullOrEmpty(updatedBy, nameof(updatedBy));
            Guard.Against.Null(isDeleted, nameof(isDeleted));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));

            var advisorPaymentToDelete = _advisorPayments
                .Where(ap1 => ap1.AdvisorPaymentDescription == advisorPaymentDescription)
                .Where(ap2 => ap2.AdvisorPaymentsAmount == advisorPaymentsAmount)
                .Where(ap3 => ap3.CreatedAt == createdAt)
                .Where(ap4 => ap4.CreatedBy == createdBy)
                .Where(ap5 => ap5.UpdatedAt == updatedAt)
                .Where(ap6 => ap6.UpdatedBy == updatedBy)
                .Where(ap7 => ap7.IsDeleted == isDeleted)
                .Where(ap8 => ap8.AdvisorId == advisorId)
                .Where(ap9 => ap9.BankAccountId == bankAccountId)
                .Where(ap10 => ap10.PaymentMethodId == paymentMethodId)
                .FirstOrDefault();

            if (advisorPaymentToDelete != null)
            {
                _advisorPayments.Remove(advisorPaymentToDelete);
                var advisorPaymentDeletedEvent =
                    new AdvisorPaymentDeletedEvent(advisorPaymentToDelete, "Mongo-History");
                Events.Add(advisorPaymentDeletedEvent);
            }
        }
    }
}
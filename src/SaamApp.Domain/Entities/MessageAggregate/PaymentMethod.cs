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
    public class PaymentMethod : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorPayment> _advisorPayments = new();

        private readonly List<CustomerPayment> _customerPayments = new();

        private PaymentMethod() { } // EF required

        //[SetsRequiredMembers]
        public PaymentMethod(Guid paymentMethodId, string paymentFrequencyCode, string paymentMethodName,
            string paymentMethodDescription, Guid tenantId)
        {
            PaymentMethodId = Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            PaymentFrequencyCode = Guard.Against.NullOrWhiteSpace(paymentFrequencyCode, nameof(paymentFrequencyCode));
            PaymentMethodName = Guard.Against.NullOrWhiteSpace(paymentMethodName, nameof(paymentMethodName));
            PaymentMethodDescription =
                Guard.Against.NullOrWhiteSpace(paymentMethodDescription, nameof(paymentMethodDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid PaymentMethodId { get; private set; }

        public string PaymentFrequencyCode { get; private set; }

        public string PaymentMethodName { get; private set; }

        public string PaymentMethodDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AdvisorPayment> AdvisorPayments => _advisorPayments.AsReadOnly();
        public IEnumerable<CustomerPayment> CustomerPayments => _customerPayments.AsReadOnly();

        public void SetPaymentFrequencyCode(string paymentFrequencyCode)
        {
            PaymentFrequencyCode = Guard.Against.NullOrEmpty(paymentFrequencyCode, nameof(paymentFrequencyCode));
        }

        public void SetPaymentMethodName(string paymentMethodName)
        {
            PaymentMethodName = Guard.Against.NullOrEmpty(paymentMethodName, nameof(paymentMethodName));
        }

        public void SetPaymentMethodDescription(string paymentMethodDescription)
        {
            PaymentMethodDescription =
                Guard.Against.NullOrEmpty(paymentMethodDescription, nameof(paymentMethodDescription));
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

        public void AddNewCustomerPayment(Guid paymentMethodId, Guid serfinsaPaymentId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var newCustomerPayment = new CustomerPayment(paymentMethodId, serfinsaPaymentId, tenantId);
            Guard.Against.DuplicateCustomerPayment(_customerPayments, newCustomerPayment, nameof(newCustomerPayment));
            _customerPayments.Add(newCustomerPayment);
            var customerPaymentAddedEvent = new CustomerPaymentCreatedEvent(newCustomerPayment, "Mongo-History");
            Events.Add(customerPaymentAddedEvent);
        }

        public void DeleteCustomerPayment(Guid paymentMethodId, Guid serfinsaPaymentId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var customerPaymentToDelete = _customerPayments
                .Where(cp1 => cp1.PaymentMethodId == paymentMethodId)
                .Where(cp2 => cp2.SerfinsaPaymentId == serfinsaPaymentId)
                .Where(cp3 => cp3.TenantId == tenantId)
                .FirstOrDefault();

            if (customerPaymentToDelete != null)
            {
                _customerPayments.Remove(customerPaymentToDelete);
                var customerPaymentDeletedEvent =
                    new CustomerPaymentDeletedEvent(customerPaymentToDelete, "Mongo-History");
                Events.Add(customerPaymentDeletedEvent);
            }
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorPaymentByRelIdsSpec : Specification<AdvisorPayment>
    {
        public AdvisorPaymentByRelIdsSpec(string advisorPaymentDescription, decimal advisorPaymentsAmount,
            DateTime createdAt, Guid createdBy, Guid advisorId, Guid bankAccountId, Guid paymentMethodId)
        {
            Guard.Against.NullOrWhiteSpace(advisorPaymentDescription, nameof(advisorPaymentDescription));
            Guard.Against.Negative(advisorPaymentsAmount, nameof(advisorPaymentsAmount));
            Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Query.Where(advisorPayment => advisorPayment.AdvisorPaymentDescription == advisorPaymentDescription &&
                                          advisorPayment.AdvisorPaymentsAmount == advisorPaymentsAmount &&
                                          advisorPayment.CreatedAt == createdAt &&
                                          advisorPayment.CreatedBy == createdBy &&
                                          advisorPayment.AdvisorId == advisorId &&
                                          advisorPayment.BankAccountId == bankAccountId &&
                                          advisorPayment.PaymentMethodId == paymentMethodId).AsNoTracking();
        }
    }
}
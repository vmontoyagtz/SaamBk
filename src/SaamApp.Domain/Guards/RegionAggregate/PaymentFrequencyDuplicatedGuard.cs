using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class PaymentFrequencyGuardExtensions
    {
        public static void DuplicatePaymentFrequency(this IGuardClause guardClause,
            IEnumerable<PaymentFrequency> existingPaymentFrequencies, PaymentFrequency newPaymentFrequency,
            string parameterName)
        {
            if (existingPaymentFrequencies.Any(a => a.PaymentFrequencyId == newPaymentFrequency.PaymentFrequencyId))
            {
                throw new DuplicatePaymentFrequencyException("Cannot add duplicate paymentFrequency.", parameterName);
            }
        }
    }
}
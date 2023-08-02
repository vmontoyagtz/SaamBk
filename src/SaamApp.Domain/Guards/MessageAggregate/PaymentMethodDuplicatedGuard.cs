using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class PaymentMethodGuardExtensions
    {
        public static void DuplicatePaymentMethod(this IGuardClause guardClause,
            IEnumerable<PaymentMethod> existingPaymentMethods, PaymentMethod newPaymentMethod, string parameterName)
        {
            if (existingPaymentMethods.Any(a => a.PaymentMethodId == newPaymentMethod.PaymentMethodId))
            {
                throw new DuplicatePaymentMethodException("Cannot add duplicate paymentMethod.", parameterName);
            }
        }
    }
}
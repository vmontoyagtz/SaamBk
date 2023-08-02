using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class SerfinsaPaymentGuardExtensions
    {
        public static void DuplicateSerfinsaPayment(this IGuardClause guardClause,
            IEnumerable<SerfinsaPayment> existingSerfinsaPayments, SerfinsaPayment newSerfinsaPayment,
            string parameterName)
        {
            if (existingSerfinsaPayments.Any(a => a.SerfinsaPaymentId == newSerfinsaPayment.SerfinsaPaymentId))
            {
                throw new DuplicateSerfinsaPaymentException("Cannot add duplicate serfinsaPayment.", parameterName);
            }
        }
    }
}
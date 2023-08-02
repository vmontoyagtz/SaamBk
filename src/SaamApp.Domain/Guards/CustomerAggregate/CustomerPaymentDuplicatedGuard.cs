using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerPaymentGuardExtensions
    {
        public static void DuplicateCustomerPayment(this IGuardClause guardClause,
            IEnumerable<CustomerPayment> existingCustomerPayments, CustomerPayment newCustomerPayment,
            string parameterName)
        {
            if (existingCustomerPayments.Any(a => a.RowId == newCustomerPayment.RowId))
            {
                throw new DuplicateCustomerPaymentException("Cannot add duplicate customerPayment.", parameterName);
            }
        }
    }
}
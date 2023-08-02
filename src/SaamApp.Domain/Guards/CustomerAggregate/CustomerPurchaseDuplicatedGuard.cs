using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerPurchaseGuardExtensions
    {
        public static void DuplicateCustomerPurchase(this IGuardClause guardClause,
            IEnumerable<CustomerPurchase> existingCustomerPurchases, CustomerPurchase newCustomerPurchase,
            string parameterName)
        {
            if (existingCustomerPurchases.Any(a => a.CustomerPurchaseId == newCustomerPurchase.CustomerPurchaseId))
            {
                throw new DuplicateCustomerPurchaseException("Cannot add duplicate customerPurchase.", parameterName);
            }
        }
    }
}
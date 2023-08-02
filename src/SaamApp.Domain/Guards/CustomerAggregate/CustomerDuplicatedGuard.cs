using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerGuardExtensions
    {
        public static void DuplicateCustomer(this IGuardClause guardClause, IEnumerable<Customer> existingCustomers,
            Customer newCustomer, string parameterName)
        {
            if (existingCustomers.Any(a => a.CustomerId == newCustomer.CustomerId))
            {
                throw new DuplicateCustomerException("Cannot add duplicate customer.", parameterName);
            }
        }
    }
}
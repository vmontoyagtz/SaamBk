using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerEmailAddressGuardExtensions
    {
        public static void DuplicateCustomerEmailAddress(this IGuardClause guardClause,
            IEnumerable<CustomerEmailAddress> existingCustomerEmailAddresses,
            CustomerEmailAddress newCustomerEmailAddress, string parameterName)
        {
            if (existingCustomerEmailAddresses.Any(a => a.RowId == newCustomerEmailAddress.RowId))
            {
                throw new DuplicateCustomerEmailAddressException("Cannot add duplicate customerEmailAddress.",
                    parameterName);
            }
        }
    }
}
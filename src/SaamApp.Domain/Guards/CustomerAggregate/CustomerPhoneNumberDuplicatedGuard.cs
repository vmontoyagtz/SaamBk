using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerPhoneNumberGuardExtensions
    {
        public static void DuplicateCustomerPhoneNumber(this IGuardClause guardClause,
            IEnumerable<CustomerPhoneNumber> existingCustomerPhoneNumbers, CustomerPhoneNumber newCustomerPhoneNumber,
            string parameterName)
        {
            if (existingCustomerPhoneNumbers.Any(a => a.RowId == newCustomerPhoneNumber.RowId))
            {
                throw new DuplicateCustomerPhoneNumberException("Cannot add duplicate customerPhoneNumber.",
                    parameterName);
            }
        }
    }
}
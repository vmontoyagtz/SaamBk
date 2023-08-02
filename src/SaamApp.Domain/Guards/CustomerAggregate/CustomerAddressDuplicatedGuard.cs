using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerAddressGuardExtensions
    {
        public static void DuplicateCustomerAddress(this IGuardClause guardClause,
            IEnumerable<CustomerAddress> existingCustomerAddresses, CustomerAddress newCustomerAddress,
            string parameterName)
        {
            if (existingCustomerAddresses.Any(a => a.RowId == newCustomerAddress.RowId))
            {
                throw new DuplicateCustomerAddressException("Cannot add duplicate customerAddress.", parameterName);
            }
        }
    }
}
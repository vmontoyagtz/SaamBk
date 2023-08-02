using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AddressGuardExtensions
    {
        public static void DuplicateAddress(this IGuardClause guardClause, IEnumerable<Address> existingAddresses,
            Address newAddress, string parameterName)
        {
            if (existingAddresses.Any(a => a.AddressId == newAddress.AddressId))
            {
                throw new DuplicateAddressException("Cannot add duplicate address.", parameterName);
            }
        }
    }
}
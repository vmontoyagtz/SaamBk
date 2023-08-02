using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class EmailAddressGuardExtensions
    {
        public static void DuplicateEmailAddress(this IGuardClause guardClause,
            IEnumerable<EmailAddress> existingEmailAddresses, EmailAddress newEmailAddress, string parameterName)
        {
            if (existingEmailAddresses.Any(a => a.EmailAddressId == newEmailAddress.EmailAddressId))
            {
                throw new DuplicateEmailAddressException("Cannot add duplicate emailAddress.", parameterName);
            }
        }
    }
}
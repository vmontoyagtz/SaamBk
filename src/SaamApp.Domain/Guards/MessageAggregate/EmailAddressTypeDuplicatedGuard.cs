using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class EmailAddressTypeGuardExtensions
    {
        public static void DuplicateEmailAddressType(this IGuardClause guardClause,
            IEnumerable<EmailAddressType> existingEmailAddressTypes, EmailAddressType newEmailAddressType,
            string parameterName)
        {
            if (existingEmailAddressTypes.Any(a => a.EmailAddressTypeId == newEmailAddressType.EmailAddressTypeId))
            {
                throw new DuplicateEmailAddressTypeException("Cannot add duplicate emailAddressType.", parameterName);
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorLoginGuardExtensions
    {
        public static void DuplicateAdvisorLogin(this IGuardClause guardClause,
            IEnumerable<AdvisorLogin> existingAdvisorLogins, AdvisorLogin newAdvisorLogin, string parameterName)
        {
            if (existingAdvisorLogins.Any(a => a.AdvisorLoginId == newAdvisorLogin.AdvisorLoginId))
            {
                throw new DuplicateAdvisorLoginException("Cannot add duplicate advisorLogin.", parameterName);
            }
        }
    }
}
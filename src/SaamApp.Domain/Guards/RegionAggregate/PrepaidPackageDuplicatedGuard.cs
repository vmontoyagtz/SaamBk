using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class PrepaidPackageGuardExtensions
    {
        public static void DuplicatePrepaidPackage(this IGuardClause guardClause,
            IEnumerable<PrepaidPackage> existingPrepaidPackages, PrepaidPackage newPrepaidPackage, string parameterName)
        {
            if (existingPrepaidPackages.Any(a => a.PrepaidPackageId == newPrepaidPackage.PrepaidPackageId))
            {
                throw new DuplicatePrepaidPackageException("Cannot add duplicate prepaidPackage.", parameterName);
            }
        }
    }
}
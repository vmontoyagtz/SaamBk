using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class ComissionGuardExtensions
    {
        public static void DuplicateComission(this IGuardClause guardClause, IEnumerable<Comission> existingComissions,
            Comission newComission, string parameterName)
        {
            if (existingComissions.Any(a => a.ComissionId == newComission.ComissionId))
            {
                throw new DuplicateComissionException("Cannot add duplicate comission.", parameterName);
            }
        }
    }
}
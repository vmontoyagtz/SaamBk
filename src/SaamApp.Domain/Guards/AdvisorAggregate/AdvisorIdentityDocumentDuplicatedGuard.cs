using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorIdentityDocumentGuardExtensions
    {
        public static void DuplicateAdvisorIdentityDocument(this IGuardClause guardClause,
            IEnumerable<AdvisorIdentityDocument> existingAdvisorIdentityDocuments,
            AdvisorIdentityDocument newAdvisorIdentityDocument, string parameterName)
        {
            if (existingAdvisorIdentityDocuments.Any(a => a.RowId == newAdvisorIdentityDocument.RowId))
            {
                throw new DuplicateAdvisorIdentityDocumentException("Cannot add duplicate advisorIdentityDocument.",
                    parameterName);
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class IdentityDocumentGuardExtensions
    {
        public static void DuplicateIdentityDocument(this IGuardClause guardClause,
            IEnumerable<IdentityDocument> existingIdentityDocuments, IdentityDocument newIdentityDocument,
            string parameterName)
        {
            if (existingIdentityDocuments.Any(a => a.IdentityDocumentId == newIdentityDocument.IdentityDocumentId))
            {
                throw new DuplicateIdentityDocumentException("Cannot add duplicate identityDocument.", parameterName);
            }
        }
    }
}
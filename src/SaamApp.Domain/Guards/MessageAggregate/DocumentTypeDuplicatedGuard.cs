using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class DocumentTypeGuardExtensions
    {
        public static void DuplicateDocumentType(this IGuardClause guardClause,
            IEnumerable<DocumentType> existingDocumentTypes, DocumentType newDocumentType, string parameterName)
        {
            if (existingDocumentTypes.Any(a => a.DocumentTypeId == newDocumentType.DocumentTypeId))
            {
                throw new DuplicateDocumentTypeException("Cannot add duplicate documentType.", parameterName);
            }
        }
    }
}
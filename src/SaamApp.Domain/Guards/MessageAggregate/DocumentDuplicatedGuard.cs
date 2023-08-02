using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class DocumentGuardExtensions
    {
        public static void DuplicateDocument(this IGuardClause guardClause, IEnumerable<Document> existingDocuments,
            Document newDocument, string parameterName)
        {
            if (existingDocuments.Any(a => a.DocumentId == newDocument.DocumentId))
            {
                throw new DuplicateDocumentException("Cannot add duplicate document.", parameterName);
            }
        }
    }
}
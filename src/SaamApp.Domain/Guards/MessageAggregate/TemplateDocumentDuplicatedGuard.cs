using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TemplateDocumentGuardExtensions
    {
        public static void DuplicateTemplateDocument(this IGuardClause guardClause,
            IEnumerable<TemplateDocument> existingTemplateDocuments, TemplateDocument newTemplateDocument,
            string parameterName)
        {
            if (existingTemplateDocuments.Any(a => a.RowId == newTemplateDocument.RowId))
            {
                throw new DuplicateTemplateDocumentException("Cannot add duplicate templateDocument.", parameterName);
            }
        }
    }
}
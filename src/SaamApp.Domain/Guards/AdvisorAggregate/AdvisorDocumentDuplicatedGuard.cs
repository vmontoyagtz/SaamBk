using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorDocumentGuardExtensions
    {
        public static void DuplicateAdvisorDocument(this IGuardClause guardClause,
            IEnumerable<AdvisorDocument> existingAdvisorDocuments, AdvisorDocument newAdvisorDocument,
            string parameterName)
        {
            if (existingAdvisorDocuments.Any(a => a.RowId == newAdvisorDocument.RowId))
            {
                throw new DuplicateAdvisorDocumentException("Cannot add duplicate advisorDocument.", parameterName);
            }
        }
    }
}
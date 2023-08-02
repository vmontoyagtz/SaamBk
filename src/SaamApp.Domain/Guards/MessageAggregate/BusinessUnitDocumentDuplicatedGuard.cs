using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BusinessUnitDocumentGuardExtensions
    {
        public static void DuplicateBusinessUnitDocument(this IGuardClause guardClause,
            IEnumerable<BusinessUnitDocument> existingBusinessUnitDocuments,
            BusinessUnitDocument newBusinessUnitDocument, string parameterName)
        {
            if (existingBusinessUnitDocuments.Any(a => a.RowId == newBusinessUnitDocument.RowId))
            {
                throw new DuplicateBusinessUnitDocumentException("Cannot add duplicate businessUnitDocument.",
                    parameterName);
            }
        }
    }
}
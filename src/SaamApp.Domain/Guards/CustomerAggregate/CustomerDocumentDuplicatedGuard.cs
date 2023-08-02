using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerDocumentGuardExtensions
    {
        public static void DuplicateCustomerDocument(this IGuardClause guardClause,
            IEnumerable<CustomerDocument> existingCustomerDocuments, CustomerDocument newCustomerDocument,
            string parameterName)
        {
            if (existingCustomerDocuments.Any(a => a.RowId == newCustomerDocument.RowId))
            {
                throw new DuplicateCustomerDocumentException("Cannot add duplicate customerDocument.", parameterName);
            }
        }
    }
}
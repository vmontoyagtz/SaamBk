using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class InvoiceGuardExtensions
    {
        public static void DuplicateInvoice(this IGuardClause guardClause, IEnumerable<Invoice> existingInvoices,
            Invoice newInvoice, string parameterName)
        {
            if (existingInvoices.Any(a => a.InvoiceId == newInvoice.InvoiceId))
            {
                throw new DuplicateInvoiceException("Cannot add duplicate invoice.", parameterName);
            }
        }
    }
}
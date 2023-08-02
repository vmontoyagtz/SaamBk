using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class InvoiceDetailGuardExtensions
    {
        public static void DuplicateInvoiceDetail(this IGuardClause guardClause,
            IEnumerable<InvoiceDetail> existingInvoiceDetails, InvoiceDetail newInvoiceDetail, string parameterName)
        {
            if (existingInvoiceDetails.Any(a => a.InvoiceDetailId == newInvoiceDetail.InvoiceDetailId))
            {
                throw new DuplicateInvoiceDetailException("Cannot add duplicate invoiceDetail.", parameterName);
            }
        }
    }
}
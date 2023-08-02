using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class ListInvoiceResponse : BaseResponse
    {
        public ListInvoiceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListInvoiceResponse()
        {
        }

        public List<InvoiceDto> Invoices { get; set; } = new();

        public int Count { get; set; }
    }
}
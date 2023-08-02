using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerDocument
{
    public class ListCustomerDocumentResponse : BaseResponse
    {
        public ListCustomerDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerDocumentResponse()
        {
        }

        public List<CustomerDocumentDto> CustomerDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerDocument
{
    public class CreateCustomerDocumentResponse : BaseResponse
    {
        public CreateCustomerDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerDocumentResponse()
        {
        }

        public CustomerDocumentDto CustomerDocument { get; set; } = new();
    }
}
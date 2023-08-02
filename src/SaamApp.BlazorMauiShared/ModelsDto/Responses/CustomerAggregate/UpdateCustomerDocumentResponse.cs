using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerDocument
{
    public class UpdateCustomerDocumentResponse : BaseResponse
    {
        public UpdateCustomerDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerDocumentResponse()
        {
        }

        public CustomerDocumentDto CustomerDocument { get; set; } = new();
    }
}
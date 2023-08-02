using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerDocument
{
    public class GetByIdCustomerDocumentResponse : BaseResponse
    {
        public GetByIdCustomerDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerDocumentResponse()
        {
        }

        public CustomerDocumentDto CustomerDocument { get; set; } = new();
    }
}
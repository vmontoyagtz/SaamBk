using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class CreateDocumentResponse : BaseResponse
    {
        public CreateDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateDocumentResponse()
        {
        }

        public DocumentDto Document { get; set; } = new();
    }
}
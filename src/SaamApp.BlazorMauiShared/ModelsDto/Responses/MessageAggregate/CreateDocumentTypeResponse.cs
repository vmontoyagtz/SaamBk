using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class CreateDocumentTypeResponse : BaseResponse
    {
        public CreateDocumentTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateDocumentTypeResponse()
        {
        }

        public DocumentTypeDto DocumentType { get; set; } = new();
    }
}
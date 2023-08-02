using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class UpdateDocumentTypeResponse : BaseResponse
    {
        public UpdateDocumentTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateDocumentTypeResponse()
        {
        }

        public DocumentTypeDto DocumentType { get; set; } = new();
    }
}
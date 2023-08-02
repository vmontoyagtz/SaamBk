using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class ListDocumentTypeResponse : BaseResponse
    {
        public ListDocumentTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListDocumentTypeResponse()
        {
        }

        public List<DocumentTypeDto> DocumentTypes { get; set; } = new();

        public int Count { get; set; }
    }
}
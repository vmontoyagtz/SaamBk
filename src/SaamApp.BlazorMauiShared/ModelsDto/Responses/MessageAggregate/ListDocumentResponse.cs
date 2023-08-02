using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class ListDocumentResponse : BaseResponse
    {
        public ListDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListDocumentResponse()
        {
        }

        public List<DocumentDto> Documents { get; set; } = new();

        public int Count { get; set; }
    }
}
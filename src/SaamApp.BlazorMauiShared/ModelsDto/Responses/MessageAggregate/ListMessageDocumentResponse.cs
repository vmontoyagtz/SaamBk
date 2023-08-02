using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageDocument
{
    public class ListMessageDocumentResponse : BaseResponse
    {
        public ListMessageDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListMessageDocumentResponse()
        {
        }

        public List<MessageDocumentDto> MessageDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}
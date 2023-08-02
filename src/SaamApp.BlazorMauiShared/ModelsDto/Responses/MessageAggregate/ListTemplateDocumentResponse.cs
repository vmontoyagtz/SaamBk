using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateDocument
{
    public class ListTemplateDocumentResponse : BaseResponse
    {
        public ListTemplateDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTemplateDocumentResponse()
        {
        }

        public List<TemplateDocumentDto> TemplateDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}
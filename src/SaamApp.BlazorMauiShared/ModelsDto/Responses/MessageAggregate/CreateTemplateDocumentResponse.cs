using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateDocument
{
    public class CreateTemplateDocumentResponse : BaseResponse
    {
        public CreateTemplateDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTemplateDocumentResponse()
        {
        }

        public TemplateDocumentDto TemplateDocument { get; set; } = new();
    }
}
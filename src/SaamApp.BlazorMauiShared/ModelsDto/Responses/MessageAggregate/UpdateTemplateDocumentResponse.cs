using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateDocument
{
    public class UpdateTemplateDocumentResponse : BaseResponse
    {
        public UpdateTemplateDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTemplateDocumentResponse()
        {
        }

        public TemplateDocumentDto TemplateDocument { get; set; } = new();
    }
}
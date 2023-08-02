using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateDocument
{
    public class GetByIdTemplateDocumentResponse : BaseResponse
    {
        public GetByIdTemplateDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTemplateDocumentResponse()
        {
        }

        public TemplateDocumentDto TemplateDocument { get; set; } = new();
    }
}
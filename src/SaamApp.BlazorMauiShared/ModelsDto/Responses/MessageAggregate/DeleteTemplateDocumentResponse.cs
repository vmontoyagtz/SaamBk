using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateDocument
{
    public class DeleteTemplateDocumentResponse : BaseResponse
    {
        public DeleteTemplateDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTemplateDocumentResponse()
        {
        }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateDocument
{
    public class CreateTemplateDocumentRequest : BaseRequest
    {
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid TemplateId { get; set; }
        public Guid TenantId { get; set; }
    }
}
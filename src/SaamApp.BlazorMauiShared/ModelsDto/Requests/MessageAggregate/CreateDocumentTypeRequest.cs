using System;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class CreateDocumentTypeRequest : BaseRequest
    {
        public string DocumentTypeName { get; set; }
        public string? DocumentTypeDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}
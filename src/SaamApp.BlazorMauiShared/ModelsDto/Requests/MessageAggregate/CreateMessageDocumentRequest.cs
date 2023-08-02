using System;

namespace SaamApp.BlazorMauiShared.Models.MessageDocument
{
    public class CreateMessageDocumentRequest : BaseRequest
    {
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid MessageId { get; set; }
        public Guid TenantId { get; set; }
    }
}
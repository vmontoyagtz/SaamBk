using System;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class DeleteDocumentTypeRequest : BaseRequest
    {
        public Guid DocumentTypeId { get; set; }
    }
}
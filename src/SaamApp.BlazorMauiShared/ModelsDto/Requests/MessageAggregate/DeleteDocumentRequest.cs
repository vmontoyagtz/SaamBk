using System;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class DeleteDocumentRequest : BaseRequest
    {
        public Guid DocumentId { get; set; }
    }
}
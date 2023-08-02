using System;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class GetByIdDocumentRequest : BaseRequest
    {
        public Guid DocumentId { get; set; }
    }
}
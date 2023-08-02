using System;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class DeleteIdentityDocumentRequest : BaseRequest
    {
        public Guid IdentityDocumentId { get; set; }
    }
}
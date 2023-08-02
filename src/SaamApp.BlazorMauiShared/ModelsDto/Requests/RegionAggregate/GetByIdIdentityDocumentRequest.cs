using System;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class GetByIdIdentityDocumentRequest : BaseRequest
    {
        public Guid IdentityDocumentId { get; set; }
    }
}
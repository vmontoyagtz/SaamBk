using System;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class DeleteIdentityDocumentResponse : BaseResponse
    {
        public DeleteIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteIdentityDocumentResponse()
        {
        }
    }
}
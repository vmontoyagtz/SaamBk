using System;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class DeleteDocumentResponse : BaseResponse
    {
        public DeleteDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteDocumentResponse()
        {
        }
    }
}
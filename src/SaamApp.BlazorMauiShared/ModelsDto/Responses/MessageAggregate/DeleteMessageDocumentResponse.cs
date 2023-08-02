using System;

namespace SaamApp.BlazorMauiShared.Models.MessageDocument
{
    public class DeleteMessageDocumentResponse : BaseResponse
    {
        public DeleteMessageDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteMessageDocumentResponse()
        {
        }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class DeleteDocumentTypeResponse : BaseResponse
    {
        public DeleteDocumentTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteDocumentTypeResponse()
        {
        }
    }
}
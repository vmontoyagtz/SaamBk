using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class UpdateDocumentResponse : BaseResponse
    {
        public UpdateDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateDocumentResponse()
        {
        }

        public DocumentDto Document { get; set; } = new();
    }
}
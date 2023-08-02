using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageDocument
{
    public class UpdateMessageDocumentResponse : BaseResponse
    {
        public UpdateMessageDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateMessageDocumentResponse()
        {
        }

        public MessageDocumentDto MessageDocument { get; set; } = new();
    }
}
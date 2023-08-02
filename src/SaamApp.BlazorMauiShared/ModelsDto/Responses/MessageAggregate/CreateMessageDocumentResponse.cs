using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageDocument
{
    public class CreateMessageDocumentResponse : BaseResponse
    {
        public CreateMessageDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateMessageDocumentResponse()
        {
        }

        public MessageDocumentDto MessageDocument { get; set; } = new();
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageDocument
{
    public class GetByIdMessageDocumentResponse : BaseResponse
    {
        public GetByIdMessageDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdMessageDocumentResponse()
        {
        }

        public MessageDocumentDto MessageDocument { get; set; } = new();
    }
}
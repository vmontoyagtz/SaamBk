using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class GetByIdDocumentResponse : BaseResponse
    {
        public GetByIdDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdDocumentResponse()
        {
        }

        public DocumentDto Document { get; set; } = new();
    }
}
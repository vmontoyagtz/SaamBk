using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class GetByIdDocumentTypeResponse : BaseResponse
    {
        public GetByIdDocumentTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdDocumentTypeResponse()
        {
        }

        public DocumentTypeDto DocumentType { get; set; } = new();
    }
}
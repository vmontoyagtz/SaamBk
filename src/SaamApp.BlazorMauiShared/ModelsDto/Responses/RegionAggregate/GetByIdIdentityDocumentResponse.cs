using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class GetByIdIdentityDocumentResponse : BaseResponse
    {
        public GetByIdIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdIdentityDocumentResponse()
        {
        }

        public IdentityDocumentDto IdentityDocument { get; set; } = new();
    }
}
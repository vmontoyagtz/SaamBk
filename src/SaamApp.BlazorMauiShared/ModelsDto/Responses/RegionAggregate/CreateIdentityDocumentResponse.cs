using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class CreateIdentityDocumentResponse : BaseResponse
    {
        public CreateIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateIdentityDocumentResponse()
        {
        }

        public IdentityDocumentDto IdentityDocument { get; set; } = new();
    }
}
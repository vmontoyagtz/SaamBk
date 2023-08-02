using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class UpdateIdentityDocumentResponse : BaseResponse
    {
        public UpdateIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateIdentityDocumentResponse()
        {
        }

        public IdentityDocumentDto IdentityDocument { get; set; } = new();
    }
}
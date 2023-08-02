using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument
{
    public class CreateAdvisorIdentityDocumentResponse : BaseResponse
    {
        public CreateAdvisorIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorIdentityDocumentResponse()
        {
        }

        public AdvisorIdentityDocumentDto AdvisorIdentityDocument { get; set; } = new();
    }
}
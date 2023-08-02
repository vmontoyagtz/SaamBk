using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument
{
    public class UpdateAdvisorIdentityDocumentResponse : BaseResponse
    {
        public UpdateAdvisorIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorIdentityDocumentResponse()
        {
        }

        public AdvisorIdentityDocumentDto AdvisorIdentityDocument { get; set; } = new();
    }
}
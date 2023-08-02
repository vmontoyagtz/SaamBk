using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument
{
    public class GetByIdAdvisorIdentityDocumentResponse : BaseResponse
    {
        public GetByIdAdvisorIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorIdentityDocumentResponse()
        {
        }

        public AdvisorIdentityDocumentDto AdvisorIdentityDocument { get; set; } = new();
    }
}
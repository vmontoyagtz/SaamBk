using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument
{
    public class ListAdvisorIdentityDocumentResponse : BaseResponse
    {
        public ListAdvisorIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorIdentityDocumentResponse()
        {
        }

        public List<AdvisorIdentityDocumentDto> AdvisorIdentityDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}
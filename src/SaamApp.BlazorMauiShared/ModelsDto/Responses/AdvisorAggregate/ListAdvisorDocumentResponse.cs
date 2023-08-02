using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorDocument
{
    public class ListAdvisorDocumentResponse : BaseResponse
    {
        public ListAdvisorDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorDocumentResponse()
        {
        }

        public List<AdvisorDocumentDto> AdvisorDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}
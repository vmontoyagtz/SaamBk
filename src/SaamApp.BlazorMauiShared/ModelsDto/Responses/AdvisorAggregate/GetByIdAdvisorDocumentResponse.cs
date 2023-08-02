using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorDocument
{
    public class GetByIdAdvisorDocumentResponse : BaseResponse
    {
        public GetByIdAdvisorDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorDocumentResponse()
        {
        }

        public AdvisorDocumentDto AdvisorDocument { get; set; } = new();
    }
}
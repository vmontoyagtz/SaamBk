using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorDocument
{
    public class CreateAdvisorDocumentResponse : BaseResponse
    {
        public CreateAdvisorDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorDocumentResponse()
        {
        }

        public AdvisorDocumentDto AdvisorDocument { get; set; } = new();
    }
}
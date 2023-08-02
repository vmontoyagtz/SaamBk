using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorDocument
{
    public class UpdateAdvisorDocumentResponse : BaseResponse
    {
        public UpdateAdvisorDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorDocumentResponse()
        {
        }

        public AdvisorDocumentDto AdvisorDocument { get; set; } = new();
    }
}
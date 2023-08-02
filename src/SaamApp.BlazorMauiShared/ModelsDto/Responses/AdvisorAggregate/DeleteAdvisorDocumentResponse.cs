using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorDocument
{
    public class DeleteAdvisorDocumentResponse : BaseResponse
    {
        public DeleteAdvisorDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorDocumentResponse()
        {
        }
    }
}
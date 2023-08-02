using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument
{
    public class DeleteAdvisorIdentityDocumentResponse : BaseResponse
    {
        public DeleteAdvisorIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorIdentityDocumentResponse()
        {
        }
    }
}
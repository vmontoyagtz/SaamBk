using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorApplicant
{
    public class DeleteAdvisorApplicantResponse : BaseResponse
    {
        public DeleteAdvisorApplicantResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorApplicantResponse()
        {
        }
    }
}
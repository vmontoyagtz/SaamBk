using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class DeleteAdvisorPhoneNumberResponse : BaseResponse
    {
        public DeleteAdvisorPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorPhoneNumberResponse()
        {
        }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class DeleteAdvisorEmailAddressResponse : BaseResponse
    {
        public DeleteAdvisorEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorEmailAddressResponse()
        {
        }
    }
}
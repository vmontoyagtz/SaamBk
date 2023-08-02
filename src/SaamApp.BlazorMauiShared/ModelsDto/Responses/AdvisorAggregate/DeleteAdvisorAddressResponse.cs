using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class DeleteAdvisorAddressResponse : BaseResponse
    {
        public DeleteAdvisorAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorAddressResponse()
        {
        }
    }
}
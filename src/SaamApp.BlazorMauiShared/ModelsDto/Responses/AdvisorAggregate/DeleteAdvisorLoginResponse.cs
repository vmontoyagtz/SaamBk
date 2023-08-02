using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class DeleteAdvisorLoginResponse : BaseResponse
    {
        public DeleteAdvisorLoginResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorLoginResponse()
        {
        }
    }
}
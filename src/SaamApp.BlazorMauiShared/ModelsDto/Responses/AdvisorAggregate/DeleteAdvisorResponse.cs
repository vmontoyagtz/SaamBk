using System;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class DeleteAdvisorResponse : BaseResponse
    {
        public DeleteAdvisorResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorResponse()
        {
        }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class DeleteAdvisorCustomerResponse : BaseResponse
    {
        public DeleteAdvisorCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorCustomerResponse()
        {
        }
    }
}
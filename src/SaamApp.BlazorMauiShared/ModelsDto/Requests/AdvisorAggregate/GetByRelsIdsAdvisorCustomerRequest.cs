using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class GetByRelsIdsAdvisorCustomerRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
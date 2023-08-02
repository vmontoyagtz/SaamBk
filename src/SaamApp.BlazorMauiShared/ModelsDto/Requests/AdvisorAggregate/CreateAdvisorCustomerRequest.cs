using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class CreateAdvisorCustomerRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
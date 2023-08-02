using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class CreateCustomerAccountRequest : BaseRequest
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
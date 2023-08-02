using System;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class DeleteCustomerRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
    }
}
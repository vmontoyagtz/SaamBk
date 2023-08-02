using System;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class GetByIdCustomerRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
    }
}
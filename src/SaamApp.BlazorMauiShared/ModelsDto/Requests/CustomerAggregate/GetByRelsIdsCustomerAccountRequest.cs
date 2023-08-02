using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class GetByRelsIdsCustomerAccountRequest : BaseRequest
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
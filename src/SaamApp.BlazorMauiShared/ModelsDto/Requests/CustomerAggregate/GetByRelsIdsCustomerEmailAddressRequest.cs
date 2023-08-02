using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class GetByRelsIdsCustomerEmailAddressRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid EmailAddressId { get; set; }
    }
}
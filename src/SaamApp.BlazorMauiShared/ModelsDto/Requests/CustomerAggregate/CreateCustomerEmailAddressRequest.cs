using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class CreateCustomerEmailAddressRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }
    }
}
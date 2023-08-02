using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber
{
    public class CreateCustomerPhoneNumberRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberTypeId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber
{
    public class GetByRelsIdsCustomerPhoneNumberRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid PhoneNumberId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class GetByIdPhoneNumberRequest : BaseRequest
    {
        public Guid PhoneNumberId { get; set; }
    }
}
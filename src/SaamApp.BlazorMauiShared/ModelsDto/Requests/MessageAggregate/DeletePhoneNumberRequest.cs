using System;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class DeletePhoneNumberRequest : BaseRequest
    {
        public Guid PhoneNumberId { get; set; }
    }
}
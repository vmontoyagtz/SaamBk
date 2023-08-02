using System;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class DeletePhoneNumberTypeRequest : BaseRequest
    {
        public Guid PhoneNumberTypeId { get; set; }
    }
}
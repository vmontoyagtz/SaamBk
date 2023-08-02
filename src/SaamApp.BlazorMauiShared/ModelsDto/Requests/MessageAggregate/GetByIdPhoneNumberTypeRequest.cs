using System;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class GetByIdPhoneNumberTypeRequest : BaseRequest
    {
        public Guid PhoneNumberTypeId { get; set; }
    }
}
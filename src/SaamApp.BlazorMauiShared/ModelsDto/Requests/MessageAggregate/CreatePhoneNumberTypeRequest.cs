using System;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class CreatePhoneNumberTypeRequest : BaseRequest
    {
        public string PhoneNumberTypeName { get; set; }
        public string? Description { get; set; }
        public Guid TenantId { get; set; }
    }
}
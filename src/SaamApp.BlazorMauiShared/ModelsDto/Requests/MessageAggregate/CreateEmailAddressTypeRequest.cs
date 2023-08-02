using System;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class CreateEmailAddressTypeRequest : BaseRequest
    {
        public string EmailAddressTypeName { get; set; }
        public string? Description { get; set; }
        public Guid TenantId { get; set; }
    }
}
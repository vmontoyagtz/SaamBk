using System;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class DeleteEmailAddressTypeRequest : BaseRequest
    {
        public Guid EmailAddressTypeId { get; set; }
    }
}
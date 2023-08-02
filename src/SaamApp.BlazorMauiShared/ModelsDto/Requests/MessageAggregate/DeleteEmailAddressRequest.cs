using System;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class DeleteEmailAddressRequest : BaseRequest
    {
        public Guid EmailAddressId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class GetByIdEmailAddressRequest : BaseRequest
    {
        public Guid EmailAddressId { get; set; }
    }
}
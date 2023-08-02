using System;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class GetByIdEmailAddressTypeRequest : BaseRequest
    {
        public Guid EmailAddressTypeId { get; set; }
    }
}
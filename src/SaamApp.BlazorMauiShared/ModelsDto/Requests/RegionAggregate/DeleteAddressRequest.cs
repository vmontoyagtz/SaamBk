using System;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class DeleteAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
    }
}
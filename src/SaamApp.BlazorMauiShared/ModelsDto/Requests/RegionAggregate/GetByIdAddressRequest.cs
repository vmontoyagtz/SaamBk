using System;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class GetByIdAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
    }
}
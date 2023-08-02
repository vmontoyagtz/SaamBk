using System;

namespace SaamApp.BlazorMauiShared.Models.AddressType
{
    public class DeleteAddressTypeRequest : BaseRequest
    {
        public Guid AddressTypeId { get; set; }
    }
}
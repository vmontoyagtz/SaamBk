using System;

namespace SaamApp.BlazorMauiShared.Models.AddressType
{
    public class GetByIdAddressTypeRequest : BaseRequest
    {
        public Guid AddressTypeId { get; set; }
    }
}
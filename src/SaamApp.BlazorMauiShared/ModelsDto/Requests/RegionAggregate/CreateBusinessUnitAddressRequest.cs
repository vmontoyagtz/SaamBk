using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class CreateBusinessUnitAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
        public Guid AddressTypeId { get; set; }
        public Guid BusinessUnitId { get; set; }
    }
}
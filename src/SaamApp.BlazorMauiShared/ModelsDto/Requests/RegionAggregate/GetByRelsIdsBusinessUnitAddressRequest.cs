using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class GetByRelsIdsBusinessUnitAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
        public Guid BusinessUnitId { get; set; }
    }
}
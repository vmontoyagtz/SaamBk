using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class GetByRelsIdsAdvisorAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
        public Guid AdvisorId { get; set; }
    }
}
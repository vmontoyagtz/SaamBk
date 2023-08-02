using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class CreateAdvisorAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
        public Guid AddressTypeId { get; set; }
        public Guid AdvisorId { get; set; }
    }
}
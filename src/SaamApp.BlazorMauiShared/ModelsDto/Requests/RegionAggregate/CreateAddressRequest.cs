using System;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class CreateAddressRequest : BaseRequest
    {
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
        public Guid RegionId { get; set; }
        public Guid StateId { get; set; }
        public string AddressStr { get; set; }
        public string ZipCode { get; set; }
        public Guid TenantId { get; set; }
    }
}
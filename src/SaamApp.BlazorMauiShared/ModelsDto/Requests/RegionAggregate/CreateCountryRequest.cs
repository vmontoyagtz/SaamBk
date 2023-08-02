using System;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class CreateCountryRequest : BaseRequest
    {
        public Guid RegionId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public Guid TenantId { get; set; }
    }
}
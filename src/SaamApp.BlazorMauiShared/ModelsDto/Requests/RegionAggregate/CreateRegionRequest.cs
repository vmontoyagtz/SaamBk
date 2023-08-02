using System;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class CreateRegionRequest : BaseRequest
    {
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public Guid TenantId { get; set; }
    }
}
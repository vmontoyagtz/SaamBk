using System;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class GetByIdRegionRequest : BaseRequest
    {
        public Guid RegionId { get; set; }
    }
}
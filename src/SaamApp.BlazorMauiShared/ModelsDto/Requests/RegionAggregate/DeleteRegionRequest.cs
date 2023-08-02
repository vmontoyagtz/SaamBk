using System;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class DeleteRegionRequest : BaseRequest
    {
        public Guid RegionId { get; set; }
    }
}
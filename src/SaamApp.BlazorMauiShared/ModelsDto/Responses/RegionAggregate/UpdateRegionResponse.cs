using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class UpdateRegionResponse : BaseResponse
    {
        public UpdateRegionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateRegionResponse()
        {
        }

        public RegionDto Region { get; set; } = new();
    }
}
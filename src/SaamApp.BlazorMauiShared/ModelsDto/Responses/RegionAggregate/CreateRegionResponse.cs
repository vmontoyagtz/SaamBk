using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class CreateRegionResponse : BaseResponse
    {
        public CreateRegionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateRegionResponse()
        {
        }

        public RegionDto Region { get; set; } = new();
    }
}
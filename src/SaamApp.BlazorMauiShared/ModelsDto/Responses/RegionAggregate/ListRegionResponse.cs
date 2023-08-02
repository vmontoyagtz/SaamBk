using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class ListRegionResponse : BaseResponse
    {
        public ListRegionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListRegionResponse()
        {
        }

        public List<RegionDto> Regions { get; set; } = new();

        public int Count { get; set; }
    }
}
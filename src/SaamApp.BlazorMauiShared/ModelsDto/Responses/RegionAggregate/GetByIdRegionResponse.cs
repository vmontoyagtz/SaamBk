using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class GetByIdRegionResponse : BaseResponse
    {
        public GetByIdRegionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdRegionResponse()
        {
        }

        public RegionDto Region { get; set; } = new();
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class GetByIdCityResponse : BaseResponse
    {
        public GetByIdCityResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCityResponse()
        {
        }

        public CityDto City { get; set; } = new();
    }
}
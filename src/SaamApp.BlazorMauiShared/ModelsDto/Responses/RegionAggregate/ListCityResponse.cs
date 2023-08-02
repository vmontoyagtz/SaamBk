using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class ListCityResponse : BaseResponse
    {
        public ListCityResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCityResponse()
        {
        }

        public List<CityDto> Cities { get; set; } = new();

        public int Count { get; set; }
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class CreateCityResponse : BaseResponse
    {
        public CreateCityResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCityResponse()
        {
        }

        public CityDto City { get; set; } = new();
    }
}
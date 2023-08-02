using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class UpdateCityResponse : BaseResponse
    {
        public UpdateCityResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCityResponse()
        {
        }

        public CityDto City { get; set; } = new();
    }
}
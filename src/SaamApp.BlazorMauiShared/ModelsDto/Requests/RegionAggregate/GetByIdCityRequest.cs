using System;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class GetByIdCityRequest : BaseRequest
    {
        public Guid CityId { get; set; }
    }
}
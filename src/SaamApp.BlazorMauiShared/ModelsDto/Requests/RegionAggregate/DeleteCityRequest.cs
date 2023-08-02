using System;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class DeleteCityRequest : BaseRequest
    {
        public Guid CityId { get; set; }
    }
}
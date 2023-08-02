using System;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class CreateCityRequest : BaseRequest
    {
        public Guid StateId { get; set; }
        public string CityName { get; set; }
        public Guid TenantId { get; set; }
    }
}
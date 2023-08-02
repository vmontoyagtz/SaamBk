using System;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class GetByIdCountryRequest : BaseRequest
    {
        public Guid CountryId { get; set; }
    }
}
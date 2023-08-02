using System;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class DeleteCountryRequest : BaseRequest
    {
        public Guid CountryId { get; set; }
    }
}
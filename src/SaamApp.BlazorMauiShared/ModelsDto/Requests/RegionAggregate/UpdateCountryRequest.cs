using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class UpdateCountryRequest : BaseRequest
    {
        public Guid CountryId { get; set; }
        public Guid RegionId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateCountryRequest FromDto(CountryDto countryDto)
        {
            return new UpdateCountryRequest
            {
                CountryId = countryDto.CountryId,
                RegionId = countryDto.RegionId,
                CountryName = countryDto.CountryName,
                CountryCode = countryDto.CountryCode,
                TenantId = countryDto.TenantId
            };
        }
    }
}
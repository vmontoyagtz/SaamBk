using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class CreateCountryResponse : BaseResponse
    {
        public CreateCountryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCountryResponse()
        {
        }

        public CountryDto Country { get; set; } = new();
    }
}
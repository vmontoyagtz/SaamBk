using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class UpdateCountryResponse : BaseResponse
    {
        public UpdateCountryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCountryResponse()
        {
        }

        public CountryDto Country { get; set; } = new();
    }
}
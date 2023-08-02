using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class GetByIdCountryResponse : BaseResponse
    {
        public GetByIdCountryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCountryResponse()
        {
        }

        public CountryDto Country { get; set; } = new();
    }
}
using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class ListCountryResponse : BaseResponse
    {
        public ListCountryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCountryResponse()
        {
        }

        public List<CountryDto> Countries { get; set; } = new();

        public int Count { get; set; }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Country;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<CreateCountryRequest, Country>();
            CreateMap<UpdateCountryRequest, Country>();
            CreateMap<DeleteCountryRequest, Country>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.City;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();
            CreateMap<CreateCityRequest, City>();
            CreateMap<UpdateCityRequest, City>();
            CreateMap<DeleteCityRequest, City>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AppConfigParam;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AppConfigParamProfile : Profile
    {
        public AppConfigParamProfile()
        {
            CreateMap<AppConfigParam, AppConfigParamDto>();
            CreateMap<AppConfigParamDto, AppConfigParam>();
            CreateMap<CreateAppConfigParamRequest, AppConfigParam>();
            CreateMap<UpdateAppConfigParamRequest, AppConfigParam>();
            CreateMap<DeleteAppConfigParamRequest, AppConfigParam>();
        }
    }
}
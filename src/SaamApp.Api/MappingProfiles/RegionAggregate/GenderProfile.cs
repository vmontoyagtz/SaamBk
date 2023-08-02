using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Gender;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>();
            CreateMap<GenderDto, Gender>();
            CreateMap<CreateGenderRequest, Gender>();
            CreateMap<UpdateGenderRequest, Gender>();
            CreateMap<DeleteGenderRequest, Gender>();
        }
    }
}
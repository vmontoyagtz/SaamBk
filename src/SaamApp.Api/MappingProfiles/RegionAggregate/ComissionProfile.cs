using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Comission;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class ComissionProfile : Profile
    {
        public ComissionProfile()
        {
            CreateMap<Comission, ComissionDto>();
            CreateMap<ComissionDto, Comission>();
            CreateMap<CreateComissionRequest, Comission>();
            CreateMap<UpdateComissionRequest, Comission>();
            CreateMap<DeleteComissionRequest, Comission>();
        }
    }
}
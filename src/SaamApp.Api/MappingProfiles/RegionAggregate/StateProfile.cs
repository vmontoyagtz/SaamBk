using AutoMapper;
using SaamApp.BlazorMauiShared.Models.State;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>();
            CreateMap<CreateStateRequest, State>();
            CreateMap<UpdateStateRequest, State>();
            CreateMap<DeleteStateRequest, State>();
        }
    }
}
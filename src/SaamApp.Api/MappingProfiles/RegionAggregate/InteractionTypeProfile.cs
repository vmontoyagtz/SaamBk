using AutoMapper;
using SaamApp.BlazorMauiShared.Models.InteractionType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class InteractionTypeProfile : Profile
    {
        public InteractionTypeProfile()
        {
            CreateMap<InteractionType, InteractionTypeDto>();
            CreateMap<InteractionTypeDto, InteractionType>();
            CreateMap<CreateInteractionTypeRequest, InteractionType>();
            CreateMap<UpdateInteractionTypeRequest, InteractionType>();
            CreateMap<DeleteInteractionTypeRequest, InteractionType>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiFeedbackProfile : Profile
    {
        public AiFeedbackProfile()
        {
            CreateMap<AiFeedback, AiFeedbackDto>();
            CreateMap<AiFeedbackDto, AiFeedback>();
            CreateMap<CreateAiFeedbackRequest, AiFeedback>();
            CreateMap<UpdateAiFeedbackRequest, AiFeedback>();
            CreateMap<DeleteAiFeedbackRequest, AiFeedback>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Faq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class FaqProfile : Profile
    {
        public FaqProfile()
        {
            CreateMap<Faq, FaqDto>();
            CreateMap<FaqDto, Faq>();
            CreateMap<CreateFaqRequest, Faq>();
            CreateMap<UpdateFaqRequest, Faq>();
            CreateMap<DeleteFaqRequest, Faq>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.PhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class PhoneNumberProfile : Profile
    {
        public PhoneNumberProfile()
        {
            CreateMap<PhoneNumber, PhoneNumberDto>();
            CreateMap<PhoneNumberDto, PhoneNumber>();
            CreateMap<CreatePhoneNumberRequest, PhoneNumber>();
            CreateMap<UpdatePhoneNumberRequest, PhoneNumber>();
            CreateMap<DeletePhoneNumberRequest, PhoneNumber>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.PhoneNumberType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class PhoneNumberTypeProfile : Profile
    {
        public PhoneNumberTypeProfile()
        {
            CreateMap<PhoneNumberType, PhoneNumberTypeDto>();
            CreateMap<PhoneNumberTypeDto, PhoneNumberType>();
            CreateMap<CreatePhoneNumberTypeRequest, PhoneNumberType>();
            CreateMap<UpdatePhoneNumberTypeRequest, PhoneNumberType>();
            CreateMap<DeletePhoneNumberTypeRequest, PhoneNumberType>();
        }
    }
}
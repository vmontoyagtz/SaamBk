using AutoMapper;
using SaamApp.BlazorMauiShared.Models.EmailAddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class EmailAddressTypeProfile : Profile
    {
        public EmailAddressTypeProfile()
        {
            CreateMap<EmailAddressType, EmailAddressTypeDto>();
            CreateMap<EmailAddressTypeDto, EmailAddressType>();
            CreateMap<CreateEmailAddressTypeRequest, EmailAddressType>();
            CreateMap<UpdateEmailAddressTypeRequest, EmailAddressType>();
            CreateMap<DeleteEmailAddressTypeRequest, EmailAddressType>();
        }
    }
}
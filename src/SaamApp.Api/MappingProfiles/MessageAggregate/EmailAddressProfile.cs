using AutoMapper;
using SaamApp.BlazorMauiShared.Models.EmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class EmailAddressProfile : Profile
    {
        public EmailAddressProfile()
        {
            CreateMap<EmailAddress, EmailAddressDto>();
            CreateMap<EmailAddressDto, EmailAddress>();
            CreateMap<CreateEmailAddressRequest, EmailAddress>();
            CreateMap<UpdateEmailAddressRequest, EmailAddress>();
            CreateMap<DeleteEmailAddressRequest, EmailAddress>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BusinessUnitEmailAddressProfile : Profile
    {
        public BusinessUnitEmailAddressProfile()
        {
            CreateMap<BusinessUnitEmailAddress, BusinessUnitEmailAddressDto>();
            CreateMap<BusinessUnitEmailAddressDto, BusinessUnitEmailAddress>();
            CreateMap<CreateBusinessUnitEmailAddressRequest, BusinessUnitEmailAddress>();
            CreateMap<UpdateBusinessUnitEmailAddressRequest, BusinessUnitEmailAddress>();
            CreateMap<DeleteBusinessUnitEmailAddressRequest, BusinessUnitEmailAddress>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BusinessUnitAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BusinessUnitAddressProfile : Profile
    {
        public BusinessUnitAddressProfile()
        {
            CreateMap<BusinessUnitAddress, BusinessUnitAddressDto>();
            CreateMap<BusinessUnitAddressDto, BusinessUnitAddress>();
            CreateMap<CreateBusinessUnitAddressRequest, BusinessUnitAddress>();
            CreateMap<UpdateBusinessUnitAddressRequest, BusinessUnitAddress>();
            CreateMap<DeleteBusinessUnitAddressRequest, BusinessUnitAddress>();
        }
    }
}
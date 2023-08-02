using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BusinessUnitType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BusinessUnitTypeProfile : Profile
    {
        public BusinessUnitTypeProfile()
        {
            CreateMap<BusinessUnitType, BusinessUnitTypeDto>();
            CreateMap<BusinessUnitTypeDto, BusinessUnitType>();
            CreateMap<CreateBusinessUnitTypeRequest, BusinessUnitType>();
            CreateMap<UpdateBusinessUnitTypeRequest, BusinessUnitType>();
            CreateMap<DeleteBusinessUnitTypeRequest, BusinessUnitType>();
        }
    }
}
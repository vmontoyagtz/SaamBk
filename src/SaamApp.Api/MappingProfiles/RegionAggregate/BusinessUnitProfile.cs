using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BusinessUnit;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BusinessUnitProfile : Profile
    {
        public BusinessUnitProfile()
        {
            CreateMap<BusinessUnit, BusinessUnitDto>();
            CreateMap<BusinessUnitDto, BusinessUnit>();
            CreateMap<CreateBusinessUnitRequest, BusinessUnit>();
            CreateMap<UpdateBusinessUnitRequest, BusinessUnit>();
            CreateMap<DeleteBusinessUnitRequest, BusinessUnit>();
        }
    }
}
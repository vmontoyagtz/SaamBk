using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BusinessUnitPhoneNumberProfile : Profile
    {
        public BusinessUnitPhoneNumberProfile()
        {
            CreateMap<BusinessUnitPhoneNumber, BusinessUnitPhoneNumberDto>();
            CreateMap<BusinessUnitPhoneNumberDto, BusinessUnitPhoneNumber>();
            CreateMap<CreateBusinessUnitPhoneNumberRequest, BusinessUnitPhoneNumber>();
            CreateMap<UpdateBusinessUnitPhoneNumberRequest, BusinessUnitPhoneNumber>();
            CreateMap<DeleteBusinessUnitPhoneNumberRequest, BusinessUnitPhoneNumber>();
        }
    }
}
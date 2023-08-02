using AutoMapper;
using SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class EmployeeEmailAddressProfile : Profile
    {
        public EmployeeEmailAddressProfile()
        {
            CreateMap<EmployeeEmailAddress, EmployeeEmailAddressDto>();
            CreateMap<EmployeeEmailAddressDto, EmployeeEmailAddress>();
            CreateMap<CreateEmployeeEmailAddressRequest, EmployeeEmailAddress>();
            CreateMap<UpdateEmployeeEmailAddressRequest, EmployeeEmailAddress>();
            CreateMap<DeleteEmployeeEmailAddressRequest, EmployeeEmailAddress>();
        }
    }
}
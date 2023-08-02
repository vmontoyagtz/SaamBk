using AutoMapper;
using SaamApp.BlazorMauiShared.Models.EmployeeAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class EmployeeAddressProfile : Profile
    {
        public EmployeeAddressProfile()
        {
            CreateMap<EmployeeAddress, EmployeeAddressDto>();
            CreateMap<EmployeeAddressDto, EmployeeAddress>();
            CreateMap<CreateEmployeeAddressRequest, EmployeeAddress>();
            CreateMap<UpdateEmployeeAddressRequest, EmployeeAddress>();
            CreateMap<DeleteEmployeeAddressRequest, EmployeeAddress>();
        }
    }
}
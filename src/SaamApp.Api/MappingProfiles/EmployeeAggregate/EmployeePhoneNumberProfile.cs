using AutoMapper;
using SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class EmployeePhoneNumberProfile : Profile
    {
        public EmployeePhoneNumberProfile()
        {
            CreateMap<EmployeePhoneNumber, EmployeePhoneNumberDto>();
            CreateMap<EmployeePhoneNumberDto, EmployeePhoneNumber>();
            CreateMap<CreateEmployeePhoneNumberRequest, EmployeePhoneNumber>();
            CreateMap<UpdateEmployeePhoneNumberRequest, EmployeePhoneNumber>();
            CreateMap<DeleteEmployeePhoneNumberRequest, EmployeePhoneNumber>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.PrepaidPackage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class PrepaidPackageProfile : Profile
    {
        public PrepaidPackageProfile()
        {
            CreateMap<PrepaidPackage, PrepaidPackageDto>();
            CreateMap<PrepaidPackageDto, PrepaidPackage>();
            CreateMap<CreatePrepaidPackageRequest, PrepaidPackage>();
            CreateMap<UpdatePrepaidPackageRequest, PrepaidPackage>();
            CreateMap<DeletePrepaidPackageRequest, PrepaidPackage>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class PrepaidPackageRedemptionProfile : Profile
    {
        public PrepaidPackageRedemptionProfile()
        {
            CreateMap<PrepaidPackageRedemption, PrepaidPackageRedemptionDto>();
            CreateMap<PrepaidPackageRedemptionDto, PrepaidPackageRedemption>();
            CreateMap<CreatePrepaidPackageRedemptionRequest, PrepaidPackageRedemption>();
            CreateMap<UpdatePrepaidPackageRedemptionRequest, PrepaidPackageRedemption>();
            CreateMap<DeletePrepaidPackageRedemptionRequest, PrepaidPackageRedemption>();
        }
    }
}
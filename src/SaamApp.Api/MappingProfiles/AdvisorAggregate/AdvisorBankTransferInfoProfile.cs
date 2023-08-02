using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorBankTransferInfoProfile : Profile
    {
        public AdvisorBankTransferInfoProfile()
        {
            CreateMap<AdvisorBankTransferInfo, AdvisorBankTransferInfoDto>();
            CreateMap<AdvisorBankTransferInfoDto, AdvisorBankTransferInfo>();
            CreateMap<CreateAdvisorBankTransferInfoRequest, AdvisorBankTransferInfo>();
            CreateMap<UpdateAdvisorBankTransferInfoRequest, AdvisorBankTransferInfo>();
            CreateMap<DeleteAdvisorBankTransferInfoRequest, AdvisorBankTransferInfo>();
        }
    }
}
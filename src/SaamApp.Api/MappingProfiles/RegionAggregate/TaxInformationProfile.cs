using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TaxInformation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TaxInformationProfile : Profile
    {
        public TaxInformationProfile()
        {
            CreateMap<TaxInformation, TaxInformationDto>();
            CreateMap<TaxInformationDto, TaxInformation>();
            CreateMap<CreateTaxInformationRequest, TaxInformation>();
            CreateMap<UpdateTaxInformationRequest, TaxInformation>();
            CreateMap<DeleteTaxInformationRequest, TaxInformation>();
        }
    }
}
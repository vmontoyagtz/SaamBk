using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TaxpayerType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TaxpayerTypeProfile : Profile
    {
        public TaxpayerTypeProfile()
        {
            CreateMap<TaxpayerType, TaxpayerTypeDto>();
            CreateMap<TaxpayerTypeDto, TaxpayerType>();
            CreateMap<CreateTaxpayerTypeRequest, TaxpayerType>();
            CreateMap<UpdateTaxpayerTypeRequest, TaxpayerType>();
            CreateMap<DeleteTaxpayerTypeRequest, TaxpayerType>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class FinancialAccountingPeriodProfile : Profile
    {
        public FinancialAccountingPeriodProfile()
        {
            CreateMap<FinancialAccountingPeriod, FinancialAccountingPeriodDto>();
            CreateMap<FinancialAccountingPeriodDto, FinancialAccountingPeriod>();
            CreateMap<CreateFinancialAccountingPeriodRequest, FinancialAccountingPeriod>();
            CreateMap<UpdateFinancialAccountingPeriodRequest, FinancialAccountingPeriod>();
            CreateMap<DeleteFinancialAccountingPeriodRequest, FinancialAccountingPeriod>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.ReportType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class ReportTypeProfile : Profile
    {
        public ReportTypeProfile()
        {
            CreateMap<ReportType, ReportTypeDto>();
            CreateMap<ReportTypeDto, ReportType>();
            CreateMap<CreateReportTypeRequest, ReportType>();
            CreateMap<UpdateReportTypeRequest, ReportType>();
            CreateMap<DeleteReportTypeRequest, ReportType>();
        }
    }
}
using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Report;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
            CreateMap<CreateReportRequest, Report>();
            CreateMap<UpdateReportRequest, Report>();
            CreateMap<DeleteReportRequest, Report>();
        }
    }
}
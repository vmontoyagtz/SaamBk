using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AuditLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AuditLogProfile : Profile
    {
        public AuditLogProfile()
        {
            CreateMap<AuditLog, AuditLogDto>();
            CreateMap<AuditLogDto, AuditLog>();
            CreateMap<CreateAuditLogRequest, AuditLog>();
            CreateMap<UpdateAuditLogRequest, AuditLog>();
            CreateMap<DeleteAuditLogRequest, AuditLog>();
        }
    }
}
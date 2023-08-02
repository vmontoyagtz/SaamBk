using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class UpdateReportRequest : BaseRequest
    {
        public Guid ReportId { get; set; }
        public Guid ReportTypeId { get; set; }
        public Guid TenantId { get; set; }
        public string ReportName { get; set; }
        public string Module { get; set; }
        public bool? IsListReport { get; set; }
        public bool? IsFormReport { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string? ReportJson { get; set; }
        public string? FrontEndMethodToCall { get; set; }
        public string? ApiMethodToCall { get; set; }
        public string? ParametersJson { get; set; }

        public static UpdateReportRequest FromDto(ReportDto reportDto)
        {
            return new UpdateReportRequest
            {
                ReportId = reportDto.ReportId,
                ReportTypeId = reportDto.ReportTypeId,
                TenantId = reportDto.TenantId,
                ReportName = reportDto.ReportName,
                Module = reportDto.Module,
                IsListReport = reportDto.IsListReport,
                IsFormReport = reportDto.IsFormReport,
                Description = reportDto.Description,
                CreatedAt = reportDto.CreatedAt,
                CreatedBy = reportDto.CreatedBy,
                UpdatedAt = reportDto.UpdatedAt,
                UpdatedBy = reportDto.UpdatedBy,
                IsDeleted = reportDto.IsDeleted,
                IsActive = reportDto.IsActive,
                ReportJson = reportDto.ReportJson,
                FrontEndMethodToCall = reportDto.FrontEndMethodToCall,
                ApiMethodToCall = reportDto.ApiMethodToCall,
                ParametersJson = reportDto.ParametersJson
            };
        }
    }
}
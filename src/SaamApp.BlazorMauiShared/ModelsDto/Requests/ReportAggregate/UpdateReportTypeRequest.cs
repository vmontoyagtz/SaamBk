using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class UpdateReportTypeRequest : BaseRequest
    {
        public Guid ReportTypeId { get; set; }
        public string ReportTypeName { get; set; }
        public string? ReportTypeDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateReportTypeRequest FromDto(ReportTypeDto reportTypeDto)
        {
            return new UpdateReportTypeRequest
            {
                ReportTypeId = reportTypeDto.ReportTypeId,
                ReportTypeName = reportTypeDto.ReportTypeName,
                ReportTypeDescription = reportTypeDto.ReportTypeDescription,
                TenantId = reportTypeDto.TenantId
            };
        }
    }
}
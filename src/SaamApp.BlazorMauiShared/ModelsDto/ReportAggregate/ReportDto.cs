using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class ReportDto
    {
        public ReportDto() { } // AutoMapper required

        public ReportDto(Guid reportId, Guid reportTypeId, Guid tenantId, string reportName, string module,
            bool? isListReport, bool? isFormReport, string? description, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, bool? isActive, string? reportJson,
            string? frontEndMethodToCall, string? apiMethodToCall, string? parametersJson)
        {
            ReportId = Guard.Against.NullOrEmpty(reportId, nameof(reportId));
            ReportTypeId = Guard.Against.NullOrEmpty(reportTypeId, nameof(reportTypeId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            ReportName = Guard.Against.NullOrWhiteSpace(reportName, nameof(reportName));
            Module = Guard.Against.NullOrWhiteSpace(module, nameof(module));
            IsListReport = isListReport;
            IsFormReport = isFormReport;
            Description = description;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            IsActive = isActive;
            ReportJson = reportJson;
            FrontEndMethodToCall = frontEndMethodToCall;
            ApiMethodToCall = apiMethodToCall;
            ParametersJson = parametersJson;
        }

        public Guid ReportId { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        [Required(ErrorMessage = "Report Name is required")]
        [MaxLength(255)]
        public string ReportName { get; set; }

        [Required(ErrorMessage = "Module is required")]
        [MaxLength(255)]
        public string Module { get; set; }

        public bool? IsListReport { get; set; }

        public bool? IsFormReport { get; set; }

        [MaxLength(255)] public string? Description { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        [MaxLength(100)] public string? ReportJson { get; set; }

        [MaxLength(255)] public string? FrontEndMethodToCall { get; set; }

        [MaxLength(255)] public string? ApiMethodToCall { get; set; }

        [MaxLength(100)] public string? ParametersJson { get; set; }

        public ReportTypeDto ReportType { get; set; }

        [Required(ErrorMessage = "Report Type is required")]
        public Guid ReportTypeId { get; set; }
    }
}
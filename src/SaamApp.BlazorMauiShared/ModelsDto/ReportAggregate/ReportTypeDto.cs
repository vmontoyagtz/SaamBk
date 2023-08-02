using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class ReportTypeDto
    {
        public ReportTypeDto() { } // AutoMapper required

        public ReportTypeDto(Guid reportTypeId, string reportTypeName, string? reportTypeDescription, Guid tenantId)
        {
            ReportTypeId = Guard.Against.NullOrEmpty(reportTypeId, nameof(reportTypeId));
            ReportTypeName = Guard.Against.NullOrWhiteSpace(reportTypeName, nameof(reportTypeName));
            ReportTypeDescription = reportTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid ReportTypeId { get; set; }

        [Required(ErrorMessage = "Report Type Name is required")]
        [MaxLength(100)]
        public string ReportTypeName { get; set; }

        [MaxLength(100)] public string? ReportTypeDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<ReportDto> Reports { get; set; } = new();
    }
}
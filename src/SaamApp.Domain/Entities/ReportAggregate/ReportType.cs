using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class ReportType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Report> _reports = new();


        private ReportType() { } // EF required

        //[SetsRequiredMembers]
        public ReportType(Guid reportTypeId, string reportTypeName, string? reportTypeDescription, Guid tenantId)
        {
            ReportTypeId = Guard.Against.NullOrEmpty(reportTypeId, nameof(reportTypeId));
            ReportTypeName = Guard.Against.NullOrWhiteSpace(reportTypeName, nameof(reportTypeName));
            ReportTypeDescription = reportTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid ReportTypeId { get; private set; }

        public string ReportTypeName { get; private set; }

        public string? ReportTypeDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Report> Reports => _reports.AsReadOnly();

        public void SetReportTypeName(string reportTypeName)
        {
            ReportTypeName = Guard.Against.NullOrEmpty(reportTypeName, nameof(reportTypeName));
        }

        public void SetReportTypeDescription(string reportTypeDescription)
        {
            ReportTypeDescription = reportTypeDescription;
        }
    }
}
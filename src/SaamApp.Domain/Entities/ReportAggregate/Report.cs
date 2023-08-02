using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Report : BaseEntityEv<Guid>, IAggregateRoot
    {
        private Report() { } // EF required

        //[SetsRequiredMembers]
        public Report(Guid reportId, Guid reportTypeId, Guid tenantId, string reportName, string module,
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

        [Key] public Guid ReportId { get; private set; }

        public Guid TenantId { get; private set; }

        public string ReportName { get; private set; }

        public string Module { get; private set; }

        public bool? IsListReport { get; private set; }

        public bool? IsFormReport { get; private set; }

        public string? Description { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public bool? IsActive { get; private set; }

        public string? ReportJson { get; private set; }

        public string? FrontEndMethodToCall { get; private set; }

        public string? ApiMethodToCall { get; private set; }

        public string? ParametersJson { get; private set; }
        public virtual ReportType ReportType { get; private set; }

        public Guid ReportTypeId { get; private set; }

        public void SetReportName(string reportName)
        {
            ReportName = Guard.Against.NullOrEmpty(reportName, nameof(reportName));
        }

        public void UpdateReportTypeForReport(Guid newReportTypeId)
        {
            Guard.Against.NullOrEmpty(newReportTypeId, nameof(newReportTypeId));
            if (newReportTypeId == ReportTypeId)
            {
                return;
            }

            ReportTypeId = newReportTypeId;
            var reportUpdatedEvent = new ReportUpdatedEvent(this, "Mongo-History");
            Events.Add(reportUpdatedEvent);
        }

        public void SetModule(string module)
        {
            Module = Guard.Against.NullOrEmpty(module, nameof(module));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetReportJson(string reportJson)
        {
            ReportJson = reportJson;
        }

        public void SetFrontEndMethodToCall(string frontEndMethodToCall)
        {
            FrontEndMethodToCall = frontEndMethodToCall;
        }

        public void SetApiMethodToCall(string apiMethodToCall)
        {
            ApiMethodToCall = apiMethodToCall;
        }

        public void SetParametersJson(string parametersJson)
        {
            ParametersJson = parametersJson;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Template : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<TemplateCategory> _templateCategories = new();

        private readonly List<TemplateDocument> _templateDocuments = new();


        private Template() { } // EF required

        //[SetsRequiredMembers]
        public Template(Guid templateId, Guid templateTypeId, string templateName, string? templateDescription,
            decimal templateUnitPrice, bool templateIsActive, DateTime createdAt, Guid createdBy, DateTime? updatedAt,
            Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            TemplateId = Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            TemplateTypeId = Guard.Against.NullOrEmpty(templateTypeId, nameof(templateTypeId));
            TemplateName = Guard.Against.NullOrWhiteSpace(templateName, nameof(templateName));
            TemplateDescription = templateDescription;
            TemplateUnitPrice = Guard.Against.Negative(templateUnitPrice, nameof(templateUnitPrice));
            TemplateIsActive = Guard.Against.Null(templateIsActive, nameof(templateIsActive));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid TemplateId { get; private set; }

        public string TemplateName { get; private set; }

        public string? TemplateDescription { get; private set; }

        public decimal TemplateUnitPrice { get; private set; }

        public bool TemplateIsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual TemplateType TemplateType { get; private set; }

        public Guid TemplateTypeId { get; private set; }
        public IEnumerable<TemplateCategory> TemplateCategories => _templateCategories.AsReadOnly();
        public IEnumerable<TemplateDocument> TemplateDocuments => _templateDocuments.AsReadOnly();

        public void SetTemplateName(string templateName)
        {
            TemplateName = Guard.Against.NullOrEmpty(templateName, nameof(templateName));
        }

        public void SetTemplateDescription(string templateDescription)
        {
            TemplateDescription = templateDescription;
        }
    }
}
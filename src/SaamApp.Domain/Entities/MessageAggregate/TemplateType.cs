using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TemplateType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Template> _templates = new();


        private TemplateType() { } // EF required

        //[SetsRequiredMembers]
        public TemplateType(Guid templateTypeId, string templateTypeName, string? templateTypeDescription,
            Guid tenantId)
        {
            TemplateTypeId = Guard.Against.NullOrEmpty(templateTypeId, nameof(templateTypeId));
            TemplateTypeName = Guard.Against.NullOrWhiteSpace(templateTypeName, nameof(templateTypeName));
            TemplateTypeDescription = templateTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid TemplateTypeId { get; private set; }

        public string TemplateTypeName { get; private set; }

        public string? TemplateTypeDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Template> Templates => _templates.AsReadOnly();

        public void SetTemplateTypeName(string templateTypeName)
        {
            TemplateTypeName = Guard.Against.NullOrEmpty(templateTypeName, nameof(templateTypeName));
        }

        public void SetTemplateTypeDescription(string templateTypeDescription)
        {
            TemplateTypeDescription = templateTypeDescription;
        }
    }
}
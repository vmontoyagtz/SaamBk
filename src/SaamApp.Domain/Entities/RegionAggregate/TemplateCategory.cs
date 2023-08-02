using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TemplateCategory : BaseEntityEv<int>, IAggregateRoot
    {
        private TemplateCategory() { } // EF required

        //[SetsRequiredMembers]
        public TemplateCategory(Guid comissionId, Guid regionAreaAdvisorCategoryId, Guid templateId, Guid tenantId)
        {
            ComissionId = Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            TemplateId = Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public int RowId { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Comission Comission { get; private set; }

        public Guid ComissionId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }

        public virtual Template Template { get; private set; }

        public Guid TemplateId { get; private set; }


        public void UpdateRegionAreaAdvisorCategoryForTemplateCategory(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var templateCategoryUpdatedEvent = new TemplateCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(templateCategoryUpdatedEvent);
        }


        public void UpdateComissionForTemplateCategory(Guid newComissionId)
        {
            Guard.Against.NullOrEmpty(newComissionId, nameof(newComissionId));
            if (newComissionId == ComissionId)
            {
                return;
            }

            ComissionId = newComissionId;
            var templateCategoryUpdatedEvent = new TemplateCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(templateCategoryUpdatedEvent);
        }


        public void UpdateTemplateForTemplateCategory(Guid newTemplateId)
        {
            Guard.Against.NullOrEmpty(newTemplateId, nameof(newTemplateId));
            if (newTemplateId == TemplateId)
            {
                return;
            }

            TemplateId = newTemplateId;
            var templateCategoryUpdatedEvent = new TemplateCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(templateCategoryUpdatedEvent);
        }
    }
}
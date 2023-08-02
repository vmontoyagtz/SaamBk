using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiAreaExpertise : BaseEntityEv<int>, IAggregateRoot
    {
        private AiAreaExpertise() { } // EF required

        //[SetsRequiredMembers]
        public AiAreaExpertise(Guid regionAreaAdvisorCategoryId, Guid modelId, Guid tenantId)
        {
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public int RowId { get; private set; }

        public Guid ModelId { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }


        public void UpdateRegionAreaAdvisorCategoryForAiAreaExpertise(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var aiAreaExpertiseUpdatedEvent = new AiAreaExpertiseUpdatedEvent(this, "Mongo-History");
            Events.Add(aiAreaExpertiseUpdatedEvent);
        }
    }
}
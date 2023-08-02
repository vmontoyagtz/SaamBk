using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class BusinessUnitCategory : BaseEntityEv<int>, IAggregateRoot
    {
        private BusinessUnitCategory() { } // EF required

        //[SetsRequiredMembers]
        public BusinessUnitCategory(Guid businessUnitId, Guid regionAreaAdvisorCategoryId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
        }

        [Key] public int RowId { get; private set; }

        public virtual BusinessUnit BusinessUnit { get; private set; }

        public Guid BusinessUnitId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }


        public void UpdateRegionAreaAdvisorCategoryForBusinessUnitCategory(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var businessUnitCategoryUpdatedEvent = new BusinessUnitCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitCategoryUpdatedEvent);
        }


        public void UpdateBusinessUnitForBusinessUnitCategory(Guid newBusinessUnitId)
        {
            Guard.Against.NullOrEmpty(newBusinessUnitId, nameof(newBusinessUnitId));
            if (newBusinessUnitId == BusinessUnitId)
            {
                return;
            }

            BusinessUnitId = newBusinessUnitId;
            var businessUnitCategoryUpdatedEvent = new BusinessUnitCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitCategoryUpdatedEvent);
        }
    }
}
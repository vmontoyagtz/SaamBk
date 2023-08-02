using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiRobotCategory : BaseEntityEv<int>, IAggregateRoot
    {
        private AiRobotCategory() { } // EF required

        //[SetsRequiredMembers]
        public AiRobotCategory(Guid aiRobotId, Guid comissionId, Guid regionAreaAdvisorCategoryId)
        {
            AiRobotId = Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            ComissionId = Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
        }

        [Key] public int RowId { get; private set; }

        public virtual AiRobot AiRobot { get; private set; }

        public Guid AiRobotId { get; private set; }

        public virtual Comission Comission { get; private set; }

        public Guid ComissionId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }


        public void UpdateRegionAreaAdvisorCategoryForAiRobotCategory(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var aiRobotCategoryUpdatedEvent = new AiRobotCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(aiRobotCategoryUpdatedEvent);
        }


        public void UpdateComissionForAiRobotCategory(Guid newComissionId)
        {
            Guard.Against.NullOrEmpty(newComissionId, nameof(newComissionId));
            if (newComissionId == ComissionId)
            {
                return;
            }

            ComissionId = newComissionId;
            var aiRobotCategoryUpdatedEvent = new AiRobotCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(aiRobotCategoryUpdatedEvent);
        }


        public void UpdateAiRobotForAiRobotCategory(Guid newAiRobotId)
        {
            Guard.Against.NullOrEmpty(newAiRobotId, nameof(newAiRobotId));
            if (newAiRobotId == AiRobotId)
            {
                return;
            }

            AiRobotId = newAiRobotId;
            var aiRobotCategoryUpdatedEvent = new AiRobotCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(aiRobotCategoryUpdatedEvent);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiRobot : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AiInteraction> _aiInteractions = new();

        private readonly List<AiRobotCategory> _aiRobotCategories = new();

        private AiRobot() { } // EF required

        //[SetsRequiredMembers]
        public AiRobot(Guid aiRobotId, string aiRobotName, string? aiRobotDescription, decimal aiRobotUnitPrice,
            bool aiRobotIsActive, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy,
            bool? isDeleted, Guid tenantId)
        {
            AiRobotId = Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            AiRobotName = Guard.Against.NullOrWhiteSpace(aiRobotName, nameof(aiRobotName));
            AiRobotDescription = aiRobotDescription;
            AiRobotUnitPrice = Guard.Against.Negative(aiRobotUnitPrice, nameof(aiRobotUnitPrice));
            AiRobotIsActive = Guard.Against.Null(aiRobotIsActive, nameof(aiRobotIsActive));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AiRobotId { get; private set; }

        public string AiRobotName { get; private set; }

        public string? AiRobotDescription { get; private set; }

        public decimal AiRobotUnitPrice { get; private set; }

        public bool AiRobotIsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AiInteraction> AiInteractions => _aiInteractions.AsReadOnly();
        public IEnumerable<AiRobotCategory> AiRobotCategories => _aiRobotCategories.AsReadOnly();

        public void SetAiRobotName(string aiRobotName)
        {
            AiRobotName = Guard.Against.NullOrEmpty(aiRobotName, nameof(aiRobotName));
        }

        public void SetAiRobotDescription(string aiRobotDescription)
        {
            AiRobotDescription = aiRobotDescription;
        }


        public void AddNewAiInteraction(AiInteraction aiInteraction)
        {
            Guard.Against.Null(aiInteraction, nameof(aiInteraction));
            Guard.Against.NullOrEmpty(aiInteraction.AiInteractionId, nameof(aiInteraction.AiInteractionId));
            Guard.Against.DuplicateAiInteraction(_aiInteractions, aiInteraction, nameof(aiInteraction));
            _aiInteractions.Add(aiInteraction);
            var aiInteractionAddedEvent = new AiInteractionCreatedEvent(aiInteraction, "Mongo-History");
            Events.Add(aiInteractionAddedEvent);
        }

        public void DeleteAiInteraction(AiInteraction aiInteraction)
        {
            Guard.Against.Null(aiInteraction, nameof(aiInteraction));
            var aiInteractionToDelete = _aiInteractions
                .Where(ai => ai.AiInteractionId == aiInteraction.AiInteractionId)
                .FirstOrDefault();
            if (aiInteractionToDelete != null)
            {
                _aiInteractions.Remove(aiInteractionToDelete);
                var aiInteractionDeletedEvent = new AiInteractionDeletedEvent(aiInteractionToDelete, "Mongo-History");
                Events.Add(aiInteractionDeletedEvent);
            }
        }

        public void AddNewAiRobotCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));

            var newAiRobotCategory = new AiRobotCategory(aiRobotId, comissionId, regionAreaAdvisorCategoryId);
            Guard.Against.DuplicateAiRobotCategory(_aiRobotCategories, newAiRobotCategory, nameof(newAiRobotCategory));
            _aiRobotCategories.Add(newAiRobotCategory);
            var aiRobotCategoryAddedEvent = new AiRobotCategoryCreatedEvent(newAiRobotCategory, "Mongo-History");
            Events.Add(aiRobotCategoryAddedEvent);
        }

        public void DeleteAiRobotCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));

            var aiRobotCategoryToDelete = _aiRobotCategories
                .Where(arc1 => arc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(arc2 => arc2.ComissionId == comissionId)
                .Where(arc3 => arc3.AiRobotId == aiRobotId)
                .FirstOrDefault();

            if (aiRobotCategoryToDelete != null)
            {
                _aiRobotCategories.Remove(aiRobotCategoryToDelete);
                var aiRobotCategoryDeletedEvent =
                    new AiRobotCategoryDeletedEvent(aiRobotCategoryToDelete, "Mongo-History");
                Events.Add(aiRobotCategoryDeletedEvent);
            }
        }
    }
}
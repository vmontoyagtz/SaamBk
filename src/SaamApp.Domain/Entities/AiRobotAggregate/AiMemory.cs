using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiMemory : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AiMemory() { } // EF required

        //[SetsRequiredMembers]
        public AiMemory(Guid aiMemoryId, Guid modelId, string? question, string? response, DateTime interactionTime,
            Guid tenantId)
        {
            AiMemoryId = Guard.Against.NullOrEmpty(aiMemoryId, nameof(aiMemoryId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Question = question;
            Response = response;
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AiMemoryId { get; private set; }

        public Guid ModelId { get; private set; }

        public string? Question { get; private set; }

        public string? Response { get; private set; }

        public DateTime InteractionTime { get; private set; }

        public Guid TenantId { get; private set; }

        public void SetQuestion(string question)
        {
            Question = question;
        }

        public void SetResponse(string response)
        {
            Response = response;
        }
    }
}
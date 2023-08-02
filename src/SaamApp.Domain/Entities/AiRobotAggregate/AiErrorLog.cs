using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiErrorLog : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AiErrorLog() { } // EF required

        //[SetsRequiredMembers]
        public AiErrorLog(Guid aiErrorLogId, Guid modelId, DateTime errorTime, string? errorMessage, Guid tenantId)
        {
            AiErrorLogId = Guard.Against.NullOrEmpty(aiErrorLogId, nameof(aiErrorLogId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            ErrorTime = Guard.Against.OutOfSQLDateRange(errorTime, nameof(errorTime));
            ErrorMessage = errorMessage;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AiErrorLogId { get; private set; }

        public Guid ModelId { get; private set; }

        public DateTime ErrorTime { get; private set; }

        public string? ErrorMessage { get; private set; }

        public Guid TenantId { get; private set; }

        public void SetErrorMessage(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class UserSession : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AiInteraction> _aiInteractions = new();


        private UserSession() { } // EF required

        //[SetsRequiredMembers]
        public UserSession(Guid sessionId, Guid applicationUserId, DateTime loginTime, DateTime? logoutTime,
            Guid tenantId)
        {
            SessionId = Guard.Against.NullOrEmpty(sessionId, nameof(sessionId));
            ApplicationUserId = Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            LoginTime = Guard.Against.OutOfSQLDateRange(loginTime, nameof(loginTime));
            LogoutTime = logoutTime;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid SessionId { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public DateTime LoginTime { get; private set; }

        public DateTime? LogoutTime { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AiInteraction> AiInteractions => _aiInteractions.AsReadOnly();
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class UserSessionDto
    {
        public UserSessionDto() { } // AutoMapper required

        public UserSessionDto(Guid sessionId, Guid applicationUserId, DateTime loginTime, DateTime? logoutTime,
            Guid tenantId)
        {
            SessionId = Guard.Against.NullOrEmpty(sessionId, nameof(sessionId));
            ApplicationUserId = Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            LoginTime = Guard.Against.OutOfSQLDateRange(loginTime, nameof(loginTime));
            LogoutTime = logoutTime;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid SessionId { get; set; }

        [Required(ErrorMessage = "Application User Id is required")]
        public Guid ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Login Time is required")]
        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AiInteractionDto> AiInteractions { get; set; } = new();
    }
}
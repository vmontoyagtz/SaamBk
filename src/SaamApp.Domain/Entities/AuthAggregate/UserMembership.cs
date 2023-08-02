using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class UserMembership : BaseEntityEv<Guid>, IAggregateRoot
    {
        private UserMembership() { } // EF required

        //[SetsRequiredMembers]
        public UserMembership(Guid userMembershipId, string username, Guid tenantId, Guid applicationUserId,
            bool? isOwner, DateTime? ownerSince, bool? isAdmin, DateTime? adminSince, bool? isAllowedToRunMobile,
            DateTime? lastLogin, string? passwordHash, string? passwordSalt, DateTime? lastPasswordChange,
            int failedLoginAttempts, bool isLocked, DateTime? lockedUntil, bool isDeleted)
        {
            UserMembershipId = Guard.Against.NullOrEmpty(userMembershipId, nameof(userMembershipId));
            Username = Guard.Against.NullOrWhiteSpace(username, nameof(username));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            ApplicationUserId = Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            IsOwner = isOwner;
            OwnerSince = ownerSince;
            IsAdmin = isAdmin;
            AdminSince = adminSince;
            IsAllowedToRunMobile = isAllowedToRunMobile;
            LastLogin = lastLogin;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            LastPasswordChange = lastPasswordChange;
            FailedLoginAttempts = Guard.Against.NegativeOrZero(failedLoginAttempts, nameof(failedLoginAttempts));
            IsLocked = Guard.Against.Null(isLocked, nameof(isLocked));
            LockedUntil = lockedUntil;
            IsDeleted = Guard.Against.Null(isDeleted, nameof(isDeleted));
        }

        [Key] public Guid UserMembershipId { get; private set; }

        public string Username { get; private set; }

        public Guid TenantId { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public bool? IsOwner { get; private set; }

        public DateTime? OwnerSince { get; private set; }

        public bool? IsAdmin { get; private set; }

        public DateTime? AdminSince { get; private set; }

        public bool? IsAllowedToRunMobile { get; private set; }

        public DateTime? LastLogin { get; private set; }

        public string? PasswordHash { get; private set; }

        public string? PasswordSalt { get; private set; }

        public DateTime? LastPasswordChange { get; private set; }

        public int FailedLoginAttempts { get; private set; }

        public bool IsLocked { get; private set; }

        public DateTime? LockedUntil { get; private set; }

        public bool IsDeleted { get; private set; }

        public void SetUsername(string username)
        {
            Username = Guard.Against.NullOrEmpty(username, nameof(username));
        }

        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void SetPasswordSalt(string passwordSalt)
        {
            PasswordSalt = passwordSalt;
        }
    }
}
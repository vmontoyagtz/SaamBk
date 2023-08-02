using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class ApplicationUser : BaseEntityEv<Guid>, IAggregateRoot
    {
        private ApplicationUser() { } // EF required

        //[SetsRequiredMembers]
        public ApplicationUser(Guid applicationUserId, string? firstName, string? lastName, string username,
            Guid createdBy, DateTime createdAt, DateTime? updatedAt, Guid? updatedBy, bool isLoginAllowed,
            DateTime? lastLogin, DateTime? lastFailedLogin, int failedLoginCount, string? email, bool isAccountVerified,
            Guid tenantId, string? hashedPassword)
        {
            ApplicationUserId = Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            FirstName = firstName;
            LastName = lastName;
            Username = Guard.Against.NullOrWhiteSpace(username, nameof(username));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsLoginAllowed = Guard.Against.Null(isLoginAllowed, nameof(isLoginAllowed));
            LastLogin = lastLogin;
            LastFailedLogin = lastFailedLogin;
            FailedLoginCount = Guard.Against.NegativeOrZero(failedLoginCount, nameof(failedLoginCount));
            Email = email;
            IsAccountVerified = Guard.Against.Null(isAccountVerified, nameof(isAccountVerified));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            HashedPassword = hashedPassword;
        }

        [Key] public Guid ApplicationUserId { get; private set; }

        public string? FirstName { get; private set; }

        public string? LastName { get; private set; }

        public string Username { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool IsLoginAllowed { get; private set; }

        public DateTime? LastLogin { get; private set; }

        public DateTime? LastFailedLogin { get; private set; }

        public int FailedLoginCount { get; private set; }

        public string? Email { get; private set; }

        public bool IsAccountVerified { get; private set; }

        public Guid TenantId { get; private set; }

        public string? HashedPassword { get; private set; }

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetUsername(string username)
        {
            Username = Guard.Against.NullOrEmpty(username, nameof(username));
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetHashedPassword(string hashedPassword)
        {
            HashedPassword = hashedPassword;
        }
    }
}
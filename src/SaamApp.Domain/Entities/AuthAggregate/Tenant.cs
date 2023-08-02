using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Tenant : BaseEntityEv<Guid>, IAggregateRoot
    {
        private Tenant() { } // EF required

        //[SetsRequiredMembers]
        public Tenant(Guid tenantId, string name, string? description, Guid createdBy, DateTime createdAt,
            DateTime? updatedAt, Guid? updatedBy, string? email, byte[]? logo, string? contactPerson,
            string? billingFrequency, DateTime? nextBillingDate, string? paymentMethod, bool isSuspended,
            string? phoneNumber, string? settingsJson, bool? isDeleted)
        {
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Description = description;
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            Email = email;
            Logo = logo;
            ContactPerson = contactPerson;
            BillingFrequency = billingFrequency;
            NextBillingDate = nextBillingDate;
            PaymentMethod = paymentMethod;
            IsSuspended = Guard.Against.Null(isSuspended, nameof(isSuspended));
            PhoneNumber = phoneNumber;
            SettingsJson = settingsJson;
            IsDeleted = isDeleted;
        }

        [Key] public Guid TenantId { get; private set; }

        public string Name { get; private set; }

        public string? Description { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public string? Email { get; private set; }

        public byte[]? Logo { get; private set; }

        public string? ContactPerson { get; private set; }

        public string? BillingFrequency { get; private set; }

        public DateTime? NextBillingDate { get; private set; }

        public string? PaymentMethod { get; private set; }

        public bool IsSuspended { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string? SettingsJson { get; private set; }

        public bool? IsDeleted { get; private set; }

        public void SetName(string name)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetContactPerson(string contactPerson)
        {
            ContactPerson = contactPerson;
        }

        public void SetBillingFrequency(string billingFrequency)
        {
            BillingFrequency = billingFrequency;
        }

        public void SetPaymentMethod(string paymentMethod)
        {
            PaymentMethod = paymentMethod;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void SetSettingsJson(string settingsJson)
        {
            SettingsJson = settingsJson;
        }
    }
}
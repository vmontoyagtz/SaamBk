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
    public class PaymentFrequency : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Advisor> _advisors = new();

        private PaymentFrequency() { } // EF required

        //[SetsRequiredMembers]
        public PaymentFrequency(Guid paymentFrequencyId, string paymentFrequencyName, string paymentFrequencyValue,
            Guid tenantId)
        {
            PaymentFrequencyId = Guard.Against.NullOrEmpty(paymentFrequencyId, nameof(paymentFrequencyId));
            PaymentFrequencyName = Guard.Against.NullOrWhiteSpace(paymentFrequencyName, nameof(paymentFrequencyName));
            PaymentFrequencyValue =
                Guard.Against.NullOrWhiteSpace(paymentFrequencyValue, nameof(paymentFrequencyValue));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid PaymentFrequencyId { get; private set; }

        public string PaymentFrequencyName { get; private set; }

        public string PaymentFrequencyValue { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Advisor> Advisors => _advisors.AsReadOnly();

        public void SetPaymentFrequencyName(string paymentFrequencyName)
        {
            PaymentFrequencyName = Guard.Against.NullOrEmpty(paymentFrequencyName, nameof(paymentFrequencyName));
        }

        public void SetPaymentFrequencyValue(string paymentFrequencyValue)
        {
            PaymentFrequencyValue = Guard.Against.NullOrEmpty(paymentFrequencyValue, nameof(paymentFrequencyValue));
        }


        public void AddNewAdvisor(Advisor advisor)
        {
            Guard.Against.Null(advisor, nameof(advisor));
            Guard.Against.NullOrEmpty(advisor.AdvisorId, nameof(advisor.AdvisorId));
            Guard.Against.DuplicateAdvisor(_advisors, advisor, nameof(advisor));
            _advisors.Add(advisor);
            var advisorAddedEvent = new AdvisorCreatedEvent(advisor, "Mongo-History");
            Events.Add(advisorAddedEvent);
        }

        public void DeleteAdvisor(Advisor advisor)
        {
            Guard.Against.Null(advisor, nameof(advisor));
            var advisorToDelete = _advisors
                .Where(a => a.AdvisorId == advisor.AdvisorId)
                .FirstOrDefault();
            if (advisorToDelete != null)
            {
                _advisors.Remove(advisorToDelete);
                var advisorDeletedEvent = new AdvisorDeletedEvent(advisorToDelete, "Mongo-History");
                Events.Add(advisorDeletedEvent);
            }
        }
    }
}
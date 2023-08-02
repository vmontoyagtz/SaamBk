using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Faq : BaseEntityEv<Guid>, IAggregateRoot
    {
        private Faq() { } // EF required

        //[SetsRequiredMembers]
        public Faq(Guid faqId, string faqQuestion, string faqAnswer, Guid tenantId)
        {
            FaqId = Guard.Against.NullOrEmpty(faqId, nameof(faqId));
            FaqQuestion = Guard.Against.NullOrWhiteSpace(faqQuestion, nameof(faqQuestion));
            FaqAnswer = Guard.Against.NullOrWhiteSpace(faqAnswer, nameof(faqAnswer));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid FaqId { get; private set; }

        public string FaqQuestion { get; private set; }

        public string FaqAnswer { get; private set; }

        public Guid TenantId { get; private set; }

        public void SetFaqQuestion(string faqQuestion)
        {
            FaqQuestion = Guard.Against.NullOrEmpty(faqQuestion, nameof(faqQuestion));
        }

        public void SetFaqAnswer(string faqAnswer)
        {
            FaqAnswer = Guard.Against.NullOrEmpty(faqAnswer, nameof(faqAnswer));
        }
    }
}
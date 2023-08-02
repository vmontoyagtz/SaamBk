using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class FaqDto
    {
        public FaqDto() { } // AutoMapper required

        public FaqDto(Guid faqId, string faqQuestion, string faqAnswer, Guid tenantId)
        {
            FaqId = Guard.Against.NullOrEmpty(faqId, nameof(faqId));
            FaqQuestion = Guard.Against.NullOrWhiteSpace(faqQuestion, nameof(faqQuestion));
            FaqAnswer = Guard.Against.NullOrWhiteSpace(faqAnswer, nameof(faqAnswer));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid FaqId { get; set; }

        [Required(ErrorMessage = "Faq Question is required")]
        [MaxLength(100)]
        public string FaqQuestion { get; set; }

        [Required(ErrorMessage = "Faq Answer is required")]
        [MaxLength(100)]
        public string FaqAnswer { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }
    }
}